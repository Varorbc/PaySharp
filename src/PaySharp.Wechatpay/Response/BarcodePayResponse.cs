using PaySharp.Core;
using PaySharp.Core.Request;
using PaySharp.Wechatpay.Domain;
using PaySharp.Wechatpay.Request;
using System.Threading;
using System.Threading.Tasks;

namespace PaySharp.Wechatpay.Response
{
    public class BarcodePayResponse : BaseResponse
    {
        /// <summary>
        /// 用户标识
        /// 用户在商户appid 下的唯一标识
        /// </summary>
        [ReName(Name = "openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 是否关注公众账号
        /// 仅在公众账号类型支付有效，取值范围：Y或N;Y-关注;N-未关注
        /// </summary>
        public string IsSubscribe { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        public string TradeType { get; set; }

        /// <summary>
        /// 银行类型，采用字符串类型的银行标识，详见银行类型
        /// </summary>
        public string BankType { get; set; }

        /// <summary>
        /// 货币类型
        /// 符合ISO 4217标准的三位字母代码，默认人民币：CNY，详见货币类型
        /// </summary>
        [ReName(Name = "fee_type")]
        public string AmountType { get; set; }

        /// <summary>
        /// 订单金额
        /// 订单总金额，单位为分
        /// </summary>
        [ReName(Name = "total_fee")]
        public int TotalAmount { get; set; }

        /// <summary>
        /// 应结订单金额
        /// 当订单使用了免充值型优惠券后返回该参数，应结订单金额=订单金额-免充值优惠券金额。
        /// </summary>
        [ReName(Name = "settlement_total_fee")]
        public int SettlementTotalAmount { get; set; }

        /// <summary>
        /// 现金支付货币类型
        /// 符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [ReName(Name = "cash_fee_type")]
        public string CashAmountType { get; set; }

        /// <summary>
        /// 现金支付金额
        /// 订单现金支付金额，详见支付金额
        /// </summary>
        [ReName(Name = "cash_fee")]
        public int CashAmount { get; set; }

        /// <summary>
        /// 代金券金额
        /// “代金券”金额小于等于订单金额，订单金额-“代金券”金额=现金支付金额，详见支付金额
        /// </summary>
        [ReName(Name = "coupon_fee")]
        public int CouponAmount { get; set; }

        /// <summary>
        /// 微信支付订单号
        /// </summary>
        [ReName(Name = "transaction_id")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 商家数据包
        /// </summary>
        public string Attach { get; set; }

        /// <summary>
        /// 支付完成时间
        /// </summary>
        public string TimeEnd { get; set; }

        /// <summary>
        /// 营销详情
        /// </summary>
        public string PromotionDetail { get; set; }

        private Merchant _merchant;

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
            _merchant = merchant;
            var barcodePayRequest = request as BarcodePayRequest;

            if (ResultCode == "SUCCESS")
            {
                barcodePayRequest.OnPaySucceed(this, null);
                return;
            }

            if (ErrCode == "USERPAYING")
            {
                var queryResponse = new QueryResponse();
                Task.Run(async () =>
                {
                    queryResponse = await PollQueryTradeStateAsync(
                        barcodePayRequest.Model.OutTradeNo,
                        barcodePayRequest.PollTime,
                        barcodePayRequest.PollCount);
                })
                .GetAwaiter()
                .GetResult();

                if (queryResponse != null)
                {
                    barcodePayRequest.OnPaySucceed(queryResponse, null);
                    return;
                }
                else
                {
                    barcodePayRequest.OnPayFailed(this, "支付超时");
                    return;
                }
            }

            barcodePayRequest.OnPayFailed(this, ErrCodeDes);
        }

        /// <summary>
        /// 轮询查询用户是否支付
        /// </summary>
        /// <param name="outTradeNo">订单号</param>
        /// <param name="pollTime">轮询间隔</param>
        /// <param name="pollCount">轮询次数</param>
        /// <returns></returns>
        private QueryResponse PollQueryTradeState(string outTradeNo, int pollTime, int pollCount)
        {
            for (int i = 0; i < pollCount; i++)
            {
                var queryRequest = new QueryRequest();
                queryRequest.AddGatewayData(new QueryModel
                {
                    OutTradeNo = outTradeNo
                });
                var queryResponse = SubmitProcess.Execute(_merchant, queryRequest);
                if (queryResponse.TradeState == "SUCCESS")
                {
                    return queryResponse;
                }

                Thread.Sleep(pollTime);
            }

            //支付超时，取消订单
            var cancelRequest = new CancelRequest();
            cancelRequest.AddGatewayData(new CancelModel
            {
                OutTradeNo = outTradeNo
            });
            SubmitProcess.Execute(_merchant, cancelRequest);

            return null;
        }

        /// <summary>
        /// 轮询查询用户是否支付
        /// </summary>
        /// <param name="outTradeNo">订单号</param>
        /// <param name="pollTime">轮询间隔</param>
        /// <param name="pollCount">轮询次数</param>
        /// <returns></returns>
        private async Task<QueryResponse> PollQueryTradeStateAsync(string outTradeNo, int pollTime, int pollCount)
        {
            return await Task.Run(() => PollQueryTradeState(outTradeNo, pollTime, pollCount));
        }
    }
}
