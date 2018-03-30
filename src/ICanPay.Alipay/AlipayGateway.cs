using ICanPay.Alipay.Domain;
using ICanPay.Alipay.Request;
using ICanPay.Core;
using ICanPay.Core.Exceptions;
using ICanPay.Core.Request;
using ICanPay.Core.Response;
using ICanPay.Core.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ICanPay.Alipay
{
    /// <summary>
    /// 支付宝网关
    /// </summary>
    public sealed class AlipayGateway : BaseGateway
    {
        #region 私有字段

        private readonly Merchant _merchant;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化支付宝网关
        /// </summary>
        /// <param name="merchant">商户数据</param>
        public AlipayGateway(Merchant merchant)
            : base(merchant)
        {
            _merchant = merchant;
        }

        #endregion

        #region 属性

        public override string GatewayUrl { get; set; } = "https://openapi.alipay.com";

        public new Merchant Merchant => _merchant;

        public new Notify Notify => (Notify)base.Notify;

        protected override bool IsSuccessPay => Notify.TradeStatus == Constant.TRADE_SUCCESS;

        protected override string[] NotifyVerifyParameter => new string[]
        {
            Constant.APP_ID,Constant.VERSION, Constant.CHARSET,
            Constant.TRADE_NO, Constant.SIGN, Constant.SIGN_TYPE
        };

        #endregion

        #region 方法

        #region 条码支付

        private void BarcodeExcute<TModel, TResponse>(Request<TModel, TResponse> request) where TResponse : IResponse
        {
            var barcodePayRequest = request as BarcodePayRequest;
            var barcodePayResponse = NetExecute(barcodePayRequest);

            if (barcodePayResponse.Code == "10000")
            {
                barcodePayRequest.OnPaySucceed(new PaySucceedEventArgs(this));
                return;
            }

            if (!string.IsNullOrEmpty(barcodePayResponse.TradeNo))
            {
                bool status = false;
                Task.Run(async () =>
                {
                    status = await PollQueryTradeStateAsync(
                        barcodePayResponse.TradeNo,
                        barcodePayRequest.PollTime,
                        barcodePayRequest.PollCount);
                })
                .GetAwaiter()
                .GetResult();

                if (status)
                {
                    barcodePayRequest.OnPaySucceed(new PaySucceedEventArgs(this));
                    return;
                }
                else
                {
                    barcodePayRequest.OnPayFailed(new PayFailedEventArgs(this)
                    {
                        Message = "支付超时"
                    });
                    return;
                }
            }

            barcodePayRequest.OnPayFailed(new PayFailedEventArgs(this)
            {
                Message = barcodePayResponse.SubMessage
            });
        }

        /// <summary>
        /// 轮询查询用户是否支付
        /// </summary>
        /// <param name="tradeNo">支付宝订单号</param>
        /// <param name="pollTime">轮询间隔</param>
        /// <param name="pollCount">轮询次数</param>
        /// <returns></returns>
        private bool PollQueryTradeState(string tradeNo, int pollTime, int pollCount)
        {
            for (int i = 0; i < pollCount; i++)
            {
                Thread.Sleep(pollTime);
                var queryRequest = new QueryRequest();
                queryRequest.AddGatewayData(new QueryModel
                {
                    TradeNo = tradeNo
                });
                var queryResponse = NetExecute(queryRequest);
                if (queryResponse.TradeStatus == Constant.TRADE_SUCCESS)
                {
                    return true;
                }
            }

            //支付超时，取消订单
            var cancelRequest = new CancelRequest();
            cancelRequest.AddGatewayData(new CancelModel
            {
                TradeNo = tradeNo
            });
            NetExecute(cancelRequest);

            return false;
        }

        /// <summary>
        /// 轮询查询用户是否支付
        /// </summary>
        /// <param name="tradeNo">支付宝订单号</param>
        /// <param name="pollTime">轮询间隔</param>
        /// <param name="pollCount">轮询次数</param>
        /// <returns></returns>
        private async Task<bool> PollQueryTradeStateAsync(string tradeNo, int pollTime, int pollCount)
        {
            return await Task.Run(() => PollQueryTradeState(tradeNo, pollTime, pollCount));
        }

        #endregion

        protected override async Task<bool> ValidateNotifyAsync()
        {
            base.Notify = await GatewayData.ToObjectAsync<Notify>(StringCase.Snake);
            if (IsSuccessResult())
            {
                return true;
            }

            return false;
        }

        protected override string BuildSign(GatewayData gatewayData)
        {
            return EncryptUtil.RSA(gatewayData.ToUrl(false), Merchant.Privatekey, Merchant.SignType);
        }

        protected override bool CheckSign(string data, string sign)
        {
            return EncryptUtil.RSAVerifyData(data, sign, Merchant.AlipayPublicKey, Merchant.SignType);
        }

        /// <summary>
        /// 是否是已成功支付的支付通知
        /// </summary>
        /// <returns></returns>
        private bool IsSuccessResult()
        {
            if (!ValidateNotifySign())
            {
                throw new GatewayException("签名不一致");
            }

            return true;
        }

        /// <summary>
        /// 验证支付宝通知的签名
        /// </summary>
        private bool ValidateNotifySign()
        {
            GatewayData.Remove(Constant.SIGN);
            GatewayData.Remove(Constant.SIGN_TYPE);

            return EncryptUtil.RSAVerifyData(GatewayData.ToUrl(false),
                Notify.Sign, Merchant.AlipayPublicKey, Merchant.SignType);
        }

        public override TResponse Execute<TModel, TResponse>(Request<TModel, TResponse> request)
        {
            if (request is WapPayRequest || request is WebPayRequest || request is AppPayRequest)
            {
                return SdkExecute(request);
            }
            else if (request is BarcodePayRequest)
            {
                BarcodeExcute(request);
                return default(TResponse);
            }
            else
            {
                return NetExecute(request);
            }
        }

        public TResponse NetExecute<TModel, TResponse>(Request<TModel, TResponse> request) where TResponse : IResponse
        {
            request.GatewayData.Add(Merchant, StringCase.Snake);
            request.GatewayData.Add(Constant.SIGN, BuildSign(request.GatewayData));

            string body = null;
            Task.Run(async () =>
            {
                body = await HttpUtil
                 .PostAsync(GatewayUrl + request.RequestUrl, request.GatewayData.ToUrl());
            })
            .GetAwaiter()
            .GetResult();

            GatewayData.FromJson(body);
            string sign = GatewayData.GetStringValue(Constant.SIGN);
            GatewayData.Remove(Constant.SIGN);
            string data = GatewayData[0].Value.ToString();

            if (!CheckSign(data, sign))
            {
                throw new GatewayException("签名验证失败");
            }

            GatewayData.FromJson(data);
            GatewayData.Add(Constant.SIGN, sign);
            GatewayData.Add(BODY, body);

            //TODO:待优化
            return GatewayData.ToObject<TResponse>(StringCase.Snake);
        }

        public TResponse SdkExecute<TModel, TResponse>(Request<TModel, TResponse> request) where TResponse : IResponse
        {
            request.RequestUrl = GatewayUrl + request.RequestUrl;
            request.GatewayData.Add(Merchant, StringCase.Snake);
            request.GatewayData.Add(Constant.SIGN, BuildSign(request.GatewayData));

            return (TResponse)Activator.CreateInstance(typeof(TResponse), request);
        }

        #endregion
    }
}