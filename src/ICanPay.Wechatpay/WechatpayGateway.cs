using ICanPay.Core;
using ICanPay.Core.Exceptions;
using ICanPay.Core.Request;
using ICanPay.Core.Utils;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ICanPay.Wechatpay
{
    /// <summary>
    /// 微信支付网关
    /// </summary>
    public sealed class WechatpayGateway : GatewayBase,
        IScanPayment, IAppPayment, IUrlPayment, IPublicPayment, IAppletPayment, IBarcodePayment,
        IQuery, ICancel, IClose, IBillDownload, IRefund, IRefundQuery
    {

        #region 私有字段

        private readonly Merchant _merchant;
        private const string ACCESSTOKENURL = "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化微信支付网关
        /// </summary>
        /// <param name="merchant">商户数据</param>
        public WechatpayGateway(Merchant merchant)
            : base(merchant)
        {
            _merchant = merchant;
        }

        #endregion

        #region 属性

        public override string GatewayUrl { get; set; } = "https://api.mch.weixin.qq.com/";

        private string UnifiedOrderUrl => GatewayUrl + "pay/unifiedorder";

        private string QueryUrl => GatewayUrl + "pay/orderquery";

        private string CancelUrl => GatewayUrl + "secapi/pay/reverse";

        private string CloseUrl => GatewayUrl + "pay/closeorder";

        private string RefundUrl => GatewayUrl + "secapi/pay/refund";

        private string RefundQueryUrl => GatewayUrl + "pay/refundquery";

        private string DownloadBillUrl => GatewayUrl + "pay/downloadbill";

        private string ReportUrl => GatewayUrl + "payitil/report";

        private string BatchQueryCommentUrl => GatewayUrl + "billcommentsp/batchquerycomment";

        private string BarcodeUrl => GatewayUrl + "pay/micropay";

        private string AuthCodeToOpenIdUrl => GatewayUrl + "tools/authcodetoopenid";

        private string RequestUrl { get; set; }

        public new Merchant Merchant => _merchant;

        public new Order Order
        {
            get => (Order)base.Order;
            set => base.Order = value;
        }

        public new Notify Notify => (Notify)base.Notify;

        protected override bool IsSuccessPay => Notify.ResultCode.ToLower() == SUCCESS;

        protected override bool IsWaitPay => Notify.TradeState.ToLower() == Constant.USERPAYING;

        protected override string[] NotifyVerifyParameter => new string[]
        { Constant.APPID, Constant.RETURN_CODE, Constant.MCH_ID, Constant.NONCE_STR, Constant.RESULT_CODE };

        #endregion

        #region 方法

        #region 扫码支付

        public string BuildScanPayment()
        {
            InitScanPayment();
            UnifiedOrder();
            return Notify.CodeUrl;
        }

        public void InitScanPayment()
        {
            Order.TradeType = Constant.NATIVE;
            Order.SpbillCreateIp = HttpUtil.LocalIpAddress;
        }

        #endregion

        #region App支付

        public string BuildAppPayment()
        {
            InitAppPayment();
            InitAppParameter();
            return GatewayData.ToJson();
        }

        public void InitAppPayment()
        {
            Order.TradeType = Constant.APP;
            Order.SpbillCreateIp = HttpUtil.RemoteIpAddress;
            UnifiedOrder();
        }

        /// <summary>
        /// 初始化APP端调起支付的参数
        /// </summary>
        private void InitAppParameter()
        {
            GatewayData.Clear();
            Merchant.NonceStr = Util.GenerateNonceStr();
            GatewayData.Add(Constant.APPID, Merchant.AppId);
            GatewayData.Add(Constant.PARTNERID, Merchant.MchId);
            GatewayData.Add(Constant.PREPAYID, Notify.PrepayId);
            GatewayData.Add(Constant.PACKAGE, "Sign=WXPay");
            GatewayData.Add(Constant.NONCEsTR, Merchant.NonceStr);
            GatewayData.Add(Constant.TIMEsTAMP, DateTime.Now.ToTimeStamp());
            GatewayData.Add(Constant.SIGN, BuildSign());
        }

        #endregion

        #region Url支付

        public string BuildUrlPayment()
        {
            InitUrlPayment();
            return Notify.MWebUrl;
        }

        public void InitUrlPayment()
        {
            Order.TradeType = Constant.MWEB;
            Order.SpbillCreateIp = HttpUtil.RemoteIpAddress;
            UnifiedOrder();
        }

        #endregion

        #region 公众号支付

        public string BuildPublicPayment()
        {
            InitPublicPayment();
            InitPublicParameter();
            return GatewayData.ToJson();
        }

        public void InitPublicPayment()
        {
            Order.TradeType = Constant.JSAPI;
            Order.SpbillCreateIp = HttpUtil.RemoteIpAddress;
            UnifiedOrder();
        }

        /// <summary>
        /// 初始化公众号调起支付的参数
        /// </summary>
        private void InitPublicParameter()
        {
            GatewayData.Clear();
            Merchant.NonceStr = Util.GenerateNonceStr();
            GatewayData.Add(Constant.APPiD, Merchant.AppId);
            GatewayData.Add(Constant.TIMESTAMP, DateTime.Now.ToTimeStamp());
            GatewayData.Add(Constant.NONCESTR, Merchant.NonceStr);
            GatewayData.Add(Constant.PACKAGE, $"{Constant.PREPAY_ID}={Notify.PrepayId}");
            GatewayData.Add(Constant.SIGNTYPE, "MD5");
            GatewayData.Add(Constant.PAYSIGN, BuildSign());
        }

        #endregion

        #region 小程序支付

        public string BuildAppletPayment()
        {
            InitAppletPayment();
            InitPublicParameter();
            return GatewayData.ToJson();
        }

        public void InitAppletPayment()
        {
            Order.TradeType = Constant.JSAPI;
            Order.SpbillCreateIp = HttpUtil.RemoteIpAddress;
            UnifiedOrder();
        }

        #endregion

        #region 条码支付

        public void BuildBarcodePayment()
        {
            InitBarcodePayment();

            Commit();

            if (Notify.ReturnCode.ToLower() == SUCCESS)
            {
                OnPaymentSucceed(new PaymentSucceedEventArgs(this));
                return;
            }

            if (!string.IsNullOrEmpty(Notify.TransactionId))
            {
                Task.Run(async () =>
                {
                    await PollQueryTradeStateAsync(new Auxiliary
                    {
                        TradeNo = Notify.TransactionId,
                        OutTradeNo = Notify.OutTradeNo
                    });
                })
                .GetAwaiter()
                .GetResult();
            }

            OnPaymentFailed(new PaymentFailedEventArgs(this)
            {
                Message = Notify.ReturnMsg
            });
        }

        public void InitBarcodePayment()
        {
            Order.SpbillCreateIp = HttpUtil.LocalIpAddress;
            UnifiedOrder();
            RequestUrl = BarcodeUrl;
        }

        /// <summary>
        /// 每隔5秒轮询判断用户是否支付,总共轮询5次
        /// </summary>
        private void PollQueryTradeState(IAuxiliary auxiliary)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(5000);
                BuildQuery(auxiliary);
                if (Notify.TradeState.ToLower() == SUCCESS)
                {
                    OnPaymentSucceed(new PaymentSucceedEventArgs(this));
                    return;
                }
            }

            BuildCancel(auxiliary);
            if (Notify.Recall == "Y")
            {
                BuildCancel(auxiliary);
            }
            OnPaymentFailed(new PaymentFailedEventArgs(this)
            {
                Message = "支付超时"
            });
        }

        /// <summary>
        /// 异步每隔5秒轮询判断用户是否支付,总共轮询5次
        /// </summary>
        private async Task PollQueryTradeStateAsync(IAuxiliary auxiliary)
        {
            await Task.Run(() => PollQueryTradeState(auxiliary));
        }

        #endregion

        #region 查询订单

        public void InitQuery(IAuxiliary auxiliary)
        {
            RequestUrl = QueryUrl;
            InitAuxiliaryParameter(GatewayAuxiliaryType.Query, auxiliary);
        }

        public INotify BuildQuery(IAuxiliary auxiliary)
        {
            InitQuery(auxiliary);

            Commit();

            return Notify;
        }

        #endregion

        #region 撤销订单

        public void InitCancel(IAuxiliary auxiliary)
        {
            RequestUrl = CancelUrl;
            InitAuxiliaryParameter(GatewayAuxiliaryType.Cancel, auxiliary);
        }

        public INotify BuildCancel(IAuxiliary auxiliary)
        {
            InitCancel(auxiliary);

            Commit(true);

            return Notify;
        }

        #endregion

        #region 关闭订单

        public INotify BuildClose(IAuxiliary auxiliary)
        {
            InitClose(auxiliary);

            Commit();

            return Notify;
        }

        public void InitClose(IAuxiliary auxiliary)
        {
            RequestUrl = CloseUrl;
            InitAuxiliaryParameter(GatewayAuxiliaryType.Close, auxiliary);
        }

        #endregion

        #region 订单退款

        public INotify BuildRefund(IAuxiliary auxiliary)
        {
            InitRefund(auxiliary);

            Commit(true);

            return Notify;
        }

        public void InitRefund(IAuxiliary auxiliary)
        {
            RequestUrl = RefundUrl;
            InitAuxiliaryParameter(GatewayAuxiliaryType.Refund, auxiliary);
        }

        #endregion

        #region 查询退款

        public INotify BuildRefundQuery(IAuxiliary auxiliary)
        {
            InitRefundQuery(auxiliary);

            Commit();

            return Notify;
        }

        public void InitRefundQuery(IAuxiliary auxiliary)
        {
            RequestUrl = RefundQueryUrl;
            InitAuxiliaryParameter(GatewayAuxiliaryType.RefundQuery, auxiliary);
        }

        #endregion

        #region 对账单下载

        public FileStream BuildBillDownload(IAuxiliary auxiliary)
        {
            InitBillDownload(auxiliary);

            Commit();

            string result = GatewayData.GetOriginalResult();

            return CreateCsv(result);
        }

        public void InitBillDownload(IAuxiliary auxiliary)
        {
            RequestUrl = DownloadBillUrl;
            InitAuxiliaryParameter(GatewayAuxiliaryType.BillDownload, auxiliary);
        }

        /// <summary>
        /// 创建Csv文件
        /// </summary>
        /// <param name="content">内容</param>
        /// <returns></returns>
        private FileStream CreateCsv(string content)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(content);
            FileStream fileStream = new FileStream($"{DateTime.Now.ToString(TIMEFORMAT)}.csv", FileMode.Create);
            fileStream.Write(buffer, 0, buffer.Length);
            fileStream.Position = 0;

            return fileStream;
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

        /// <summary>
        /// 初始化订单参数
        /// </summary>
        private void InitOrderParameter()
        {
            GatewayData.Clear();
            Merchant.NonceStr = Util.GenerateNonceStr();
            Merchant.DeviceInfo = Constant.WEB;
            GatewayData.Add(Merchant, StringCase.Snake);
            GatewayData.Add(Order, StringCase.Snake);
            GatewayData.Add(Constant.SIGN, BuildSign());
        }

        /// <summary>
        /// 初始化辅助参数
        /// </summary>
        /// <param name="gatewayAuxiliaryType">辅助类型</param>
        /// <param name="auxiliary">辅助参数</param>
        private void InitAuxiliaryParameter(GatewayAuxiliaryType gatewayAuxiliaryType, IAuxiliary auxiliary)
        {
            auxiliary.Validate(gatewayAuxiliaryType);
            Merchant.NonceStr = Util.GenerateNonceStr();
            GatewayData.Add(Merchant, StringCase.Snake);
            GatewayData.Add(auxiliary, StringCase.Snake);
            GatewayData.Add(Constant.SIGN, BuildSign());
        }

        /// <summary>
        /// 统一下单
        /// </summary>
        /// <returns></returns>
        private void UnifiedOrder()
        {
            RequestUrl = UnifiedOrderUrl;
            InitOrderParameter();

            Commit();
        }

        /// <summary>
        /// 通过code获取AccessToken
        /// </summary>
        /// <param name="code"></param>
        public OAuth GetAccessTokenByCode(string code)
        {
            string result = null;
            Task.Run(async () =>
            {
                result = await HttpUtil
                .GetAsync(string.Format(ACCESSTOKENURL, Merchant.AppId, Merchant.AppSecret, code));
            })
            .GetAwaiter()
            .GetResult();
            GatewayData.FromJson(result);

            int _code = GatewayData.GetIntValue(Constant.ERRCODE);
            int _msg = GatewayData.GetIntValue(Constant.ERRMSG);
            if (_code == 40029)
            {
                throw new GatewayException($"{_code} {_msg}");
            }

            return GatewayData.ToObject<OAuth>(StringCase.Snake);
        }

        /// <summary>
        /// 通过授权码获取OpenId
        /// </summary>
        /// <param name="authCode">授权码</param>
        public string GetOpenIdByAuthCode(string authCode)
        {
            GatewayData.Clear();
            Merchant.NonceStr = Util.GenerateNonceStr();
            GatewayData.Add(Constant.APPID, Merchant.AppId);
            GatewayData.Add(Constant.MCH_ID, Merchant.AppId);
            GatewayData.Add(Constant.AUTH_CODE, Merchant.AppId);
            GatewayData.Add(Constant.NONCE_STR, Merchant.NonceStr);
            GatewayData.Add(Constant.SIGN, BuildSign());
            RequestUrl = AuthCodeToOpenIdUrl;

            Commit();

            return Notify.OpenId;
        }

        /// <summary>
        /// 读取返回结果
        /// </summary>
        /// <param name="result"></param>
        private void ReadReturnResult(string result)
        {
            GatewayData.FromXml(result);
            base.Notify = GatewayData.ToObject<Notify>(StringCase.Snake);
            IsSuccessReturn();
        }

        /// <summary>
        /// 获得签名
        /// </summary>
        /// <returns></returns>
        private string BuildSign()
        {
            GatewayData.Remove(Constant.SIGN);

            string data = $"{GatewayData.ToUrl(false)}&key={Merchant.Key}";
            return EncryptUtil.MD5(data);
        }

        /// <summary>
        /// 是否是已成功支付的支付通知
        /// </summary>
        /// <returns></returns>
        private bool IsSuccessResult()
        {
            if (Notify.ReturnCode.ToLower() != SUCCESS)
            {
                throw new GatewayException("不是成功的返回码");
            }

            if (Notify.Sign != BuildSign())
            {
                throw new GatewayException("签名不一致");
            }

            if (Notify.ResultCode.ToLower() == SUCCESS)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 提交请求
        /// </summary>
        /// <param name="isCert">是否添加证书</param>
        private void Commit(bool isCert = false)
        {
            var cert = isCert ? new X509Certificate2(Merchant.SslCertPath, Merchant.SslCertPassword) : null;

            string result = null;
            Task.Run(async () =>
            {
                result = await HttpUtil
                .PostAsync(RequestUrl, GatewayData.ToXml(), cert);
            })
            .GetAwaiter()
            .GetResult();
            ReadReturnResult(result);
        }

        /// <summary>
        /// 是否是已成功的返回
        /// </summary>
        /// <returns></returns>
        private bool IsSuccessReturn()
        {
            if (Notify.ReturnCode == FAIL)
            {
                throw new GatewayException(Notify.ReturnMsg);
            }

            return true;
        }

        protected override void WriteSuccessFlag()
        {
            GatewayData.Add(Constant.RETURN_CODE, SUCCESS.ToUpper());
            HttpUtil.Write(GatewayData.ToXml());
        }

        protected override void WriteFailureFlag()
        {
            GatewayData.Add(Constant.RETURN_CODE, FAIL);
            HttpUtil.Write(GatewayData.ToXml());
        }

        public override T SdkExecute<T>(Request<T> request)
        {
            throw new NotImplementedException();
        }

        public override T Execute<T>(Request<T> request)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
