using ICanPay.Core;
using System;
using System.Threading.Tasks;

namespace ICanPay.Alipay
{
    /// <summary>
    /// 支付宝网关
    /// </summary>
    public sealed class AlipayGateway : GatewayBase, IPaymentForm, IPaymentUrl, IPaymentApp
    {

        #region 私有字段

        private Merchant merchant;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化支付宝网关
        /// </summary>
        /// <param name="merchant">商户数据</param>
        public AlipayGateway(Merchant merchant)
            : base(merchant)
        {
            this.merchant = merchant;
        }

        #endregion

        #region 属性

        public override GatewayType GatewayType => GatewayType.Alipay;

        public override string GatewayUrl => "https://openapi.alipay.com/gateway.do";

        public new Merchant Merchant => merchant;

        public new Order Order => (Order)base.Order;

        public new Notify Notify => (Notify)base.Notify;

        #endregion

        #region 方法

        public string BuildPaymentForm()
        {
            InitOrderParameter();

            return GetFormHtml(GatewayUrl);
        }

        public string BuildPaymentUrl()
        {
            InitOrderParameter();

            return $"{GatewayUrl}?{GetPaymentQueryString()}";
        }

        public string BuildPaymentApp()
        {
            InitOrderParameter();

            return GetPaymentQueryString();
        }

        protected override async Task<bool> CheckNotifyDataAsync()
        {
            await ReadNotifyAsync();
            if (await IsSuccessResultAsync())
            {
                return true;
            }

            return false;
        }

        protected override void SupplementaryAppParameter()
        {
            Merchant.Method = Constant.APP;
            Order.ProductCode = Constant.QUICK_MSECURITY_PAY;
        }

        protected override void SupplementaryWebParameter()
        {
            if (!string.IsNullOrEmpty(Merchant.ReturnUrl))
            {
                GatewayData.Add(Constant.RETURN_URL, Merchant.ReturnUrl);
            }

            Merchant.Method = Constant.WEB;
            Order.ProductCode = Constant.FAST_INSTANT_TRADE_PAY;
        }

        protected override void SupplementaryWapParameter()
        {
            if (!string.IsNullOrEmpty(Merchant.ReturnUrl))
            {
                GatewayData.Add(Constant.RETURN_URL, Merchant.ReturnUrl);
            }

            Merchant.Method = Constant.WAP;
            Order.ProductCode = Constant.QUICK_WAP_WAY;
        }

        protected override void SupplementaryScanParameter()
        {
            if (string.IsNullOrEmpty(Order.Scene))
            {
                throw new Exception("请设置支付场景");
            }

            if (string.IsNullOrEmpty(Order.AuthCode))
            {
                throw new Exception("请设置支付授权码");
            }

            if (!string.IsNullOrEmpty(Merchant.AppAuthToken))
            {
                GatewayData.Add(Constant.APP_AUTH_TOKEN, Merchant.AppAuthToken);
            }

            Merchant.Method = Constant.SCAN;
            Order.ProductCode = Constant.FACE_TO_FACE_PAYMENT;
        }

        /// <summary>
        /// 初始化订单参数
        /// </summary>
        protected override void InitOrderParameter()
        {
            base.InitOrderParameter();
            Merchant.BizContent = Utility.SerializeObject(Order);
            GatewayData.Add(Constant.APP_ID, Merchant.AppId);
            GatewayData.Add(Constant.METHOD, Merchant.Method);
            GatewayData.Add(Constant.FORMAT, Merchant.Format);
            GatewayData.Add(Constant.CHARSET, Merchant.Charset);
            GatewayData.Add(Constant.SIGN_TYPE, Merchant.SignType);
            GatewayData.Add(Constant.TIMESTAMP, Merchant.Timestamp.ToString(TIME_FORMAT));
            GatewayData.Add(Constant.VERSION, Merchant.Version);
            GatewayData.Add(Constant.NOTIFY_URL, Merchant.NotifyUrl);
            GatewayData.Add(Constant.BIZ_CONTENT, Merchant.BizContent);
            Merchant.Sign = Signature.RSASign(GatewayData.ToUrl(), Merchant.Privatekey, Merchant.Charset, Merchant.SignType, false);
            GatewayData.Add(Constant.SIGN, Merchant.Sign);    // 签名需要在最后设置，以免缺少参数。
        }

        private string GetPaymentQueryString()
        {
            return GatewayData.ToUrlEncode();
        }

        /// <summary>
        /// 读取通知
        /// </summary>
        private void ReadNotify()
        {
            var type = typeof(Notify);
            var notify = Activator.CreateInstance(type);
            var properties = type.GetProperties();

            foreach (var item in properties)
            {
                string key = item
                    .GetCustomAttributesData()[0]
                    .NamedArguments[0]
                    .TypedValue
                    .Value
                    .ToString();
                object value = GatewayData.GetValue(key);

                if (value != null)
                {
                    item.SetValue(notify, Convert.ChangeType(value, item.PropertyType));
                }
            }

            base.Notify = (Notify)notify;
        }

        /// <summary>
        /// 异步读取通知
        /// </summary>
        private async Task ReadNotifyAsync()
        {
            await Task.Run(() => ReadNotify());
        }

        /// <summary>
        /// 是否是已成功支付的支付通知
        /// </summary>
        /// <returns></returns>
        private async Task<bool> IsSuccessResultAsync()
        {
            if (ValidateNotifyParameter() && ValidateNotifySign() && await ValidateNotifyIdAsync())
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 检查支付通知，是否支付成功，签名是否正确。
        /// </summary>
        /// <returns></returns>
        private bool ValidateNotifyParameter()
        {
            // 支付状态是否为成功。
            if (string.Compare(Notify.TradeStatus, Constant.TRADE_SUCCESS) == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 验证支付宝通知的签名
        /// </summary>
        private bool ValidateNotifySign()
        {
            Merchant.Sign = Signature.RSASign(GatewayData.ToUrl(Constant.SIGN, Constant.SIGN_TYPE), Merchant.Privatekey, Merchant.Charset, Merchant.SignType, false);
            // 验证通知的签名
            if (string.Compare(Notify.Sign, Merchant.Sign) == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 验证网关的通知Id是否有效
        /// </summary>
        private bool ValidateNotifyId()
        {
            // 服务器异步通知的通知Id则会在输出标志成功接收到通知的success字符串后失效。
            if (string.Compare(Utility.ReadPage(GetValidateNotifyUrl()), TRUE) == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 异步验证网关的通知Id是否有效
        /// </summary>
        private async Task<bool> ValidateNotifyIdAsync()
        {
            return await Task.Run(() => ValidateNotifyId());
        }

        /// <summary>
        /// 获得验证支付宝通知的Url
        /// </summary>
        private string GetValidateNotifyUrl()
        {
            return $"{GatewayUrl}?service=notify_verify&partner={Merchant.AppId}&notify_id={Notify.NotifyId}";
        }

        #endregion

    }
}