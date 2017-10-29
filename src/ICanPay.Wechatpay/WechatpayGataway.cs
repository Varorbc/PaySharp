using ICanPay.Core;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace ICanPay.Wechatpay
{
    /// <summary>
    /// 微信支付网关
    /// </summary>
    public sealed class WechatpayGataway : GatewayBase,
        IScanPayment, IAppPayment, IUrlPayment, IPublicPayment, IAppletPayment, IBarcodePayment,
        IQuery, ICancel
    {

        #region 私有字段

        private Merchant merchant;
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

        public override GatewayType GatewayType => GatewayType.Wechatpay;

        public override string GatewayUrl { get; set; } = UNIFIEDORDERGATEWAYURL;

        public new Merchant Merchant => merchant;

        public new Order Order => (Order)base.Order;

        public new Notify Notify => (Notify)base.Notify;

        protected override bool IsSuccessPay => Notify.TradeState.ToLower() == SUCCESS;

        protected override bool IsWaitPay => Notify.TradeState.ToLower() == USERPAYING;

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
            UnifiedOrder();
            InitAppParameter();
            return GatewayData.ToJson();
        }

        public void InitAppPayment()
        {
            Order.TradeType = Constant.APP;
            Order.SpbillCreateIp = HttpUtil.RemoteIpAddress.ToString();
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
            UnifiedOrder();
            return Notify.MWebUrl;
        }

        public void InitUrlPayment()
        {
            Order.TradeType = Constant.MWEB;
            Order.SpbillCreateIp = HttpUtil.RemoteIpAddress.ToString();
        }

        #endregion

        #region 公众号支付

        public string BuildPublicPayment()
        {
            InitPublicPayment();
            UnifiedOrder();
            InitPublicParameter();
            return GatewayData.ToJson();
        }

        public void InitPublicPayment()
        {
            Order.TradeType = Constant.JSAPI;
            Order.SpbillCreateIp = HttpUtil.RemoteIpAddress.ToString();
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
            UnifiedOrder();
            InitPublicParameter();
            return GatewayData.ToJson();
        }

        public void InitAppletPayment()
        {
            Order.TradeType = Constant.JSAPI;
            Order.SpbillCreateIp = HttpUtil.RemoteIpAddress.ToString();
        }

        #endregion

        #region 条码支付

        public void BuildBarcodePayment()
        {
            InitBarcodePayment();

            Commit();

            PollQueryTradeState();
        }

        public void InitBarcodePayment()
        {
            GatewayUrl = BARCODEGATEWAYURL;
            Order.SpbillCreateIp = HttpUtil.LocalIpAddress.ToString();
        }

        /// <summary>
        /// 每隔5秒轮询判断用户是否支付,总共轮询5次
        /// </summary>
        private void PollQueryTradeState()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(5000);
                BuildQuery();
                if (IsSuccessPay)
                {
                    OnPaymentSucceed(new PaymentSucceedEventArgs(this));
                    return;
                }
            }

            BuildCancel();
            if (Notify.Recall == "Y")
            {
                BuildCancel();
            }
            OnPaymentFailed(new PaymentFailedEventArgs(this));
        }

        /// <summary>
        /// 异步每隔5秒轮询判断用户是否支付,总共轮询5次
        /// </summary>
        private async Task PollAsync()
        {
            await Task.Run(() => PollQueryTradeState());
        }

        #endregion

        #region 查询订单

        public void InitQuery()
        {
            GatewayUrl = QUERYGATEWAYURL;
            Merchant.NonceStr = Util.GenerateNonceStr();
            GatewayData.Add(Merchant);
            GatewayData.Add(Constant.OUT_TRADE_NO, Order.OutTradeNo);
            Merchant.Sign = BuildSign();
            GatewayData.Add(Constant.SIGN, Merchant.Sign);
        }

        public INotify BuildQuery()
        {
            InitQuery();

            Commit();

            return Notify;
        }

        #endregion

        #region 撤销订单

        public void InitCancel()
        {
            InitQuery();
            GatewayUrl = CANCELGATEWAYURL;
        }

        public INotify BuildCancel()
        {
            InitCancel();

            Commit(true);

            return Notify;
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
            Merchant.NonceStr = Util.GenerateNonceStr();
            Merchant.DeviceInfo = Constant.WEB;
            GatewayData.Add(Merchant);
            GatewayData.Add(Order);
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
            string data = GatewayData.ToUrl(Constant.SIGN) + "&key=" + Merchant.Key;
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
