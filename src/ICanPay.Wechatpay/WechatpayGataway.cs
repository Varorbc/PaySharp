using ICanPay.Core;
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
    public sealed class WechatpayGataway : GatewayBase,
        IScanPayment, IAppPayment, IUrlPayment, IPublicPayment, IAppletPayment, IBarcodePayment,
        IQuery, ICancel, IClose, IBillDownload, IRefund, IRefundQuery
    {

        #region 私有字段

        private readonly Merchant merchant;
        private const string USERPAYING = "USERPAYING";
        private const string UNIFIEDORDERGATEWAYURL = "https://api.mch.weixin.qq.com/pay/unifiedorder";
        private const string QUERYGATEWAYURL = "https://api.mch.weixin.qq.com/pay/orderquery";
        private const string CANCELGATEWAYURL = "https://api.mch.weixin.qq.com/secapi/pay/reverse";
        private const string CLOSEORDERGATEWAYURL = "https://api.mch.weixin.qq.com/pay/closeorder";
        private const string REFUNDGATEWAYURL = "https://api.mch.weixin.qq.com/secapi/pay/refund";
        private const string REFUNDQUERYGATEWAYURL = "https://api.mch.weixin.qq.com/pay/refundquery";
        private const string DOWNLOADBILLGATEWAYURL = "https://api.mch.weixin.qq.com/pay/downloadbill";
        private const string REPORTGATEWAYURL = "https://api.mch.weixin.qq.com/payitil/report";
        private const string BATCHQUERYCOMMENTGATEWAYURL = "https://api.mch.weixin.qq.com/billcommentsp/batchquerycomment";
        private const string BARCODEGATEWAYURL = "https://api.mch.weixin.qq.com/pay/micropay";
        private const string ACCESSTOKENURL = "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";
        private const string AUTHCODETOOPENIDURL = "https://api.mch.weixin.qq.com/tools/authcodetoopenid";

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化微信支付网关
        /// </summary>
        /// <param name="merchant">商户数据</param>
        public WechatpayGataway(Merchant merchant)
            : base(merchant)
        {
            this.merchant = merchant;
        }

        #endregion

        #region 属性

        public override string GatewayUrl { get; set; } = UNIFIEDORDERGATEWAYURL;

        public new Merchant Merchant => merchant;

        public new Order Order => (Order)base.Order;

        public new Notify Notify => (Notify)base.Notify;

        protected override bool IsSuccessPay => Notify.TradeState.ToLower() == SUCCESS;

        protected override bool IsWaitPay => Notify.TradeState.ToLower() == USERPAYING;

        protected override string[] NotifyVerifyParameter => new string[] { "return_code", "appid", "mch_id", "nonce_str", "result_code" };

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
            Order.SpbillCreateIp = HttpUtil.LocalIpAddress.ToString();
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
            Order.SpbillCreateIp = HttpUtil.RemoteIpAddress.ToString();
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
            GatewayData.Add(Constant.NONCE_STR, Merchant.NonceStr);
            GatewayData.Add(Constant.TIMESTAMP, DateTime.Now.ToTimeStamp());
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
            Order.SpbillCreateIp = HttpUtil.RemoteIpAddress.ToString();
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
            OAuth oAuth = GetAccessTokenByCode(Order.Code);
            Order.OpenId = oAuth.OpenId;
            Order.TradeType = Constant.JSAPI;
            Order.SpbillCreateIp = HttpUtil.RemoteIpAddress.ToString();
            UnifiedOrder();
        }

        /// <summary>
        /// 初始化公众号调起支付的参数
        /// </summary>
        private void InitPublicParameter()
        {
            GatewayData.Clear();
            Merchant.NonceStr = Util.GenerateNonceStr();
            GatewayData.Add(Constant.APPID, Merchant.AppId);
            GatewayData.Add(Constant.TIMESTAMP, DateTime.Now.ToTimeStamp());
            GatewayData.Add(Constant.NONCE_STR, Merchant.NonceStr);
            GatewayData.Add(Constant.PACKAGE, $"{Constant.PREPAY_ID}={Notify.PrepayId}");
            GatewayData.Add(Constant.SIGN_TYPE, "MD5");
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
            Order.SpbillCreateIp = HttpUtil.RemoteIpAddress.ToString();
            UnifiedOrder();
        }

        #endregion

        #region 条码支付

        public void BuildBarcodePayment()
        {
            InitBarcodePayment();

            Commit();

            if (!string.IsNullOrEmpty(Notify.TransactionId))
            {
                PollQueryTradeState(new Auxiliary
                {
                    TradeNo = Notify.TransactionId,
                    OutTradeNo = Notify.OutTradeNo
                });
            }
        }

        public void InitBarcodePayment()
        {
            Order.SpbillCreateIp = HttpUtil.LocalIpAddress.ToString();
            UnifiedOrder();
            GatewayUrl = BARCODEGATEWAYURL;
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
                if (IsSuccessPay)
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
            OnPaymentFailed(new PaymentFailedEventArgs(this));
        }

        /// <summary>
        /// 异步每隔5秒轮询判断用户是否支付,总共轮询5次
        /// </summary>
        private async Task PollAsync(IAuxiliary auxiliary)
        {
            await Task.Run(() => PollQueryTradeState(auxiliary));
        }

        #endregion

        #region 查询订单

        public void InitQuery(IAuxiliary auxiliary)
        {
            GatewayUrl = QUERYGATEWAYURL;
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
            GatewayUrl = CANCELGATEWAYURL;
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
            GatewayUrl = CLOSEORDERGATEWAYURL;
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
            GatewayUrl = REFUNDGATEWAYURL;
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
            GatewayUrl = REFUNDQUERYGATEWAYURL;
            InitAuxiliaryParameter(GatewayAuxiliaryType.RefundQuery, auxiliary);
        }

        #endregion

        #region 对账单下载

        public FileStream BuildBillDownload(IAuxiliary auxiliary)
        {
            InitBillDownload(auxiliary);

            Commit();

            string result = GatewayData.GetDefaultResult();

            return CreateCsv(result);
        }

        public void InitBillDownload(IAuxiliary auxiliary)
        {
            GatewayUrl = DOWNLOADBILLGATEWAYURL;
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

        protected override async Task<bool> CheckNotifyDataAsync()
        {
            base.Notify = await GatewayData.ToObjectAsync<Notify>();

            if (IsSuccessResult())
            {
                return true;
            }

            return false;
        }

        private void InitOrderParameter()
        {
            GatewayData.Clear();
            Order.Amount *= 100;
            Merchant.NonceStr = Util.GenerateNonceStr();
            Merchant.DeviceInfo = Constant.WEB;
            GatewayData.Add(Merchant);
            GatewayData.Add(Order);
            Merchant.Sign = BuildSign();
            GatewayData.Add(Constant.SIGN, Merchant.Sign);
        }

        private void InitAuxiliaryParameter(GatewayAuxiliaryType gatewayAuxiliaryType, IAuxiliary auxiliary)
        {
            auxiliary.Validate(gatewayAuxiliaryType);
            Merchant.NonceStr = Util.GenerateNonceStr();
            GatewayData.Add(Merchant);
            GatewayData.Add(auxiliary);
            Merchant.Sign = BuildSign();
            GatewayData.Add(Constant.SIGN, Merchant.Sign);
        }

        public void InitFormPayment()
        {
            Order.SpbillCreateIp = HttpUtil.RemoteIpAddress.ToString();
        }

        /// <summary>
        /// 统一下单
        /// </summary>
        /// <returns></returns>
        private void UnifiedOrder()
        {
            GatewayUrl = UNIFIEDORDERGATEWAYURL;
            InitOrderParameter();

            ValidateParameter(Merchant);
            ValidateParameter(Order);

            Commit();
        }

        /// <summary>
        /// 通过code获取AccessToken
        /// </summary>
        /// <param name="code"></param>
        public OAuth GetAccessTokenByCode(string code)
        {
            string result = HttpUtil
                .GetAsync(string.Format(ACCESSTOKENURL, Merchant.AppId, Merchant.AppSecret, code))
                .GetAwaiter()
                .GetResult();
            GatewayData.FromJson(result);

            int _code = GatewayData.GetIntValue(Constant.ERRCODE);
            int _msg = GatewayData.GetIntValue(Constant.ERRMSG);
            if (_code == 40029)
            {
                throw new Exception($"{_code} {_msg}");
            }

            return GatewayData.ToObject<OAuth>();
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
            Merchant.Sign = BuildSign();
            GatewayData.Add(Constant.SIGN, Merchant.Sign);
            GatewayUrl = AUTHCODETOOPENIDURL;

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
            base.Notify = GatewayData.ToObject<Notify>();
            IsSuccessReturn();
        }

        /// <summary>
        /// 获得签名
        /// </summary>
        /// <returns></returns>
        private string BuildSign()
        {
            string data = $"{GatewayData.ToUrl(Constant.SIGN)}&key={Merchant.Key}";
            return EncryptUtil.MD5(data);
        }

        /// <summary>
        /// 是否是已成功支付的支付通知
        /// </summary>
        /// <returns></returns>
        private bool IsSuccessResult()
        {
            if (Notify.ReturnCode.ToLower() == SUCCESS && Notify.ResultCode.ToLower() == SUCCESS && Notify.Sign == BuildSign())
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

            string result = HttpUtil
                .PostAsync(GatewayUrl, GatewayData.ToXml(), cert)
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
                throw new Exception(Notify.ReturnMsg);
            }

            return true;
        }

        public override void WriteSuccessFlag()
        {
            GatewayData.Add(Constant.RETURN_CODE, SUCCESS);
            HttpUtil.Write(GatewayData.ToXml());
        }

        #endregion
    }
}
