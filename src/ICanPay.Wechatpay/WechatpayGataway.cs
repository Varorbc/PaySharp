using ICanPay.Core;
using System;
using System.Threading.Tasks;

namespace ICanPay.Wechatpay
{
    /// <summary>
    /// 微信支付网关
    /// </summary>
    public sealed class WechatpayGataway : GatewayBase,
        IScanPayment, IAppPayment, IUrlPayment, IPublicPayment, IAppletPayment,
        IQuery, ICancel
    {

        #region 私有字段

        private Merchant merchant;
        private const string unifiedOrderGatewayUrl = "https://api.mch.weixin.qq.com/pay/unifiedorder";
        private const string queryGatewayUrl = "https://api.mch.weixin.qq.com/pay/orderquery";
        private const string cancelGatewayUrl = "https://api.mch.weixin.qq.com/pay/closeorder";
        private const string refundGatewayUrl = "https://api.mch.weixin.qq.com/secapi/pay/refund";
        private const string refundQueryGatewayUrl = "https://api.mch.weixin.qq.com/pay/refundquery";
        private const string downloadBillGatewayUrl = "https://api.mch.weixin.qq.com/pay/downloadbill";
        private const string reportGatewayUrl = "https://api.mch.weixin.qq.com/payitil/report";
        private const string batchQueryCommentGatewayUrl = "https://api.mch.weixin.qq.com/billcommentsp/batchquerycomment";
        private const string barcodeGatewayUrl = "https://api.mch.weixin.qq.com/pay/micropay";

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

        public override string GatewayUrl { get; set; } = unifiedOrderGatewayUrl;

        public new Merchant Merchant => merchant;

        public new Order Order => (Order)base.Order;

        public new Notify Notify => (Notify)base.Notify;

        protected override bool IsSuccessPay => throw new NotImplementedException();

        protected override bool IsWaitPay => throw new NotImplementedException();

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

        public string BuildPaymentBarcode()
        {
            InitBarcodePayment();

            Commit();

            throw new NotImplementedException();
        }

        public void InitBarcodePayment()
        {
            GatewayUrl = barcodeGatewayUrl;
            Order.SpbillCreateIp = HttpUtil.LocalIpAddress.ToString();
        }

        #endregion

        #region 查询订单

        public void InitQuery()
        {
            GatewayUrl = queryGatewayUrl;
            Merchant.NonceStr = Util.GenerateNonceStr();
            GatewayData.Add(Constant.APPID, Merchant.AppId);
            GatewayData.Add(Constant.MCH_ID, Merchant.MchId);
            GatewayData.Add(Constant.OUT_TRADE_NO, Order.OutTradeNo);
            GatewayData.Add(Constant.NONCE_STR, Merchant.NonceStr);
            GatewayData.Add(Constant.SIGN_TYPE, Merchant.SignType);
            GatewayData.Add(Constant.SIGN, BuildSign());
        }

        public INotify BuildQuery()
        {
            InitQuery();

            Commit();

            return Notify;
        }

        #endregion

        #region 关闭订单

        public void InitCancel()
        {
            InitQuery();
            GatewayUrl = cancelGatewayUrl;
        }

        public INotify BuildCancel()
        {
            InitCancel();

            Commit();

            return Notify;
        }

        #endregion

        protected override async Task<bool> CheckNotifyDataAsync()
        {
            await ReadNotifyAsync<Notify>();

            if (IsSuccessResult())
            {
                return true;
            }

            return false;
        }

        private void InitOrderParameter()
        {
            #region 商户数据
            Merchant.NonceStr = Util.GenerateNonceStr();
            GatewayData.Add(Constant.APPID, Merchant.AppId);
            GatewayData.Add(Constant.MCH_ID, Merchant.MchId);
            GatewayData.Add(Constant.NONCE_STR, Merchant.NonceStr);
            GatewayData.Add(Constant.SIGN_TYPE, Merchant.SignType);
            GatewayData.Add(Constant.NOTIFY_URL, Merchant.NotifyUrl);
            GatewayData.Add(Constant.DEVICE_INFO, Constant.WEB);

            #endregion

            #region 订单数据

            GatewayData.Add(Constant.BODY, Order.Body);
            GatewayData.Add(Constant.OUT_TRADE_NO, Order.OutTradeNo);
            GatewayData.Add(Constant.FEE_TYPE, Order.FeeType);
            GatewayData.Add(Constant.TOTAL_FEE, Order.Amount * 100);
            GatewayData.Add(Constant.TIME_START, Order.TimeStart);
            GatewayData.Add(Constant.SPBILL_CREATE_IP, Order.SpbillCreateIp);

            if (!string.IsNullOrEmpty(Order.TradeType))
            {
                GatewayData.Add(Constant.TRADE_TYPE, Order.TradeType);
            }

            if (!string.IsNullOrEmpty(Order.Detail))
            {
                GatewayData.Add(Constant.DETAIL, Order.Detail);
            }

            if (!string.IsNullOrEmpty(Order.Attach))
            {
                GatewayData.Add(Constant.ATTACH, Order.Attach);
            }

            if (!string.IsNullOrEmpty(Order.TimeExpire))
            {
                GatewayData.Add(Constant.TIME_EXPIRE, Order.TimeExpire);
            }

            if (!string.IsNullOrEmpty(Order.GoodsTag))
            {
                GatewayData.Add(Constant.GOODS_TAG, Order.GoodsTag);
            }

            if (!string.IsNullOrEmpty(Order.ProductId))
            {
                GatewayData.Add(Constant.PRODUCT_ID, Order.ProductId);
            }

            if (!string.IsNullOrEmpty(Order.LimitPay))
            {
                GatewayData.Add(Constant.LIMIT_PAY, Order.LimitPay);
            }

            if (!string.IsNullOrEmpty(Order.OpenId))
            {
                GatewayData.Add(Constant.OPENID, Order.OpenId);
            }

            if (!string.IsNullOrEmpty(Order.SceneInfo))
            {
                GatewayData.Add(Constant.SCENE_INFO, Order.SceneInfo);
            }

            if (!string.IsNullOrEmpty(Order.AuthCode))
            {
                GatewayData.Add(Constant.AUTH_CODE, Order.AuthCode);
            }

            #endregion

            GatewayData.Add(Constant.SIGN, BuildSign());
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
            GatewayUrl = unifiedOrderGatewayUrl;
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
            ReadNotify<Notify>();
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
        private void Commit()
        {
            string result = HttpUtil
                .PostAsync(GatewayUrl, GatewayData.ToXml())
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
