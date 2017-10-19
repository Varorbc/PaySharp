using ICanPay.Core;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ICanPay.Wechatpay
{
    /// <summary>
    /// 微信支付网关
    /// </summary>
    public sealed class WechatpayGataway : GatewayBase, IPaymentQRCode, IQueryNow, IPaymentApp
    {

        #region 私有字段

        private Merchant merchant;
        private const string queryGatewayUrl = "https://api.mch.weixin.qq.com/pay/orderquery";

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

        public override string GatewayUrl => "https://api.mch.weixin.qq.com/pay/unifiedorder";

        public new Merchant Merchant => merchant;

        public new Order Order => (Order)base.Order;

        #endregion

        #region 方法

        protected override async Task<bool> CheckNotifyDataAsync()
        {
            if (IsSuccessResult())
            {
                ReadNotifyOrder();
                return true;
            }

            return false;
        }

        public string BuildPaymentQRCode()
        {
            return GetWeixinPaymentUrl(CreateOrder());
        }

        private string CreateOrder()
        {
            InitOrderParameter();
            return Util
                .PostAsync(queryGatewayUrl, GatewayData.ToXml())
                .GetAwaiter()
                .GetResult();
        }

        public bool QueryNow()
        {
            return CheckQueryResult(QueryOrder());
        }

        private string QueryOrder()
        {
            InitQueryOrderParameter();
            return Util
                .PostAsync(queryGatewayUrl, GatewayData.ToXml())
                .GetAwaiter()
                .GetResult();
        }

        protected override void InitOrderParameter()
        {
            base.InitOrderParameter();

            #region 商户数据
            Merchant.NonceStr = GenerateNonceStr();
            GatewayData.Add(Constant.APPID, Merchant.AppId);
            GatewayData.Add(Constant.MCH_ID, Merchant.MchId);
            GatewayData.Add(Constant.NONCE_STR, Merchant.NonceStr);
            GatewayData.Add(Constant.SIGN_TYPE, Merchant.SignType);
            GatewayData.Add(Constant.NOTIFY_URL, Merchant.NotifyUrl);
            if (!string.IsNullOrEmpty(Merchant.DeviceInfo))
            {
                GatewayData.Add(Constant.DEVICE_INFO, Merchant.DeviceInfo);
            }

            #endregion

            #region 订单数据

            GatewayData.Add(Constant.BODY, Order.Body);
            GatewayData.Add(Constant.OUT_TRADE_NO, Order.OutTradeNo);
            GatewayData.Add(Constant.FEE_TYPE, Order.FeeType);
            GatewayData.Add(Constant.TOTAL_FEE, (Order.Amount * 100).ToString());
            GatewayData.Add(Constant.TIME_START, Order.TimeStart);
            GatewayData.Add(Constant.TRADE_TYPE, Constant.APP);
            GatewayData.Add(Constant.SPBILL_CREATE_IP, Order.SpbillCreateIp);

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

            #endregion

            Merchant.Sign = BuildSign();
            GatewayData.Add(Constant.SIGN, Merchant.Sign);    // 签名需要在最后设置，以免缺少参数。
        }

        protected override void SupplementaryAppParameter()
        {
            Order.SpbillCreateIp = HttpUtil.RemoteIpAddress.ToString();
        }

        protected override void SupplementaryWebParameter()
        {
            Order.SpbillCreateIp = HttpUtil.RemoteIpAddress.ToString();
        }

        protected override void SupplementaryWapParameter()
        {
            Order.SpbillCreateIp = HttpUtil.RemoteIpAddress.ToString();
        }

        protected override void SupplementaryScanParameter()
        {
            Order.SpbillCreateIp = HttpUtil.LocalIpAddress.ToString();
        }

        public string BuildPaymentApp()
        {
            string result = CreateOrder();
            ReadReturnResult(result);
            return null;
        }

        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <returns></returns>
        private string GenerateNonceStr()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        /// <summary>
        /// 读取通知中的订单金额、订单编号
        /// </summary>
        private void ReadNotifyOrder()
        {
            Order.OutTradeNo = GatewayData.GetStringValue(Constant.OUT_TRADE_NO);
            Order.Amount = GatewayData.GetIntValue(Constant.TOTAL_FEE) * 0.01;
        }

        /// <summary>
        /// 读取返回结果
        /// </summary>
        /// <param name="result"></param>
        private void ReadReturnResult(string result)
        {
            ClearGatewayData();
            GatewayData.FromXml(result);
            IsSuccessReturn();
        }

        /// <summary>
        /// 获得签名
        /// </summary>
        /// <returns></returns>
        private string BuildSign()
        {
            StringBuilder signBuilder = new StringBuilder();
            foreach (var item in GatewayData.Values)
            {
                // 空值的参数与sign参数不参与签名
                if (string.Compare(Constant.SIGN, item.Key) != 0)
                {
                    signBuilder.AppendFormat("{0}={1}&", item.Key, item.Value);
                }
            }

            signBuilder.Append("key=" + Merchant.Key);
            return Util.GetMD5(signBuilder.ToString());
        }

        /// <summary>
        /// 获得微信支付的URL
        /// </summary>
        /// <param name="resultXml">创建订单返回的数据</param>
        /// <returns></returns>
        private string GetWeixinPaymentUrl(string resultXml)
        {
            // 需要先清除之前创建订单的参数，否则会对接收到的参数造成干扰。
            ClearGatewayData();
            GatewayData.FromXml(resultXml);
            if (IsSuccessResult())
            {
                return GatewayData.GetStringValue(Constant.CODE_URL);
            }

            return string.Empty;
        }

        /// <summary>
        /// 是否是已成功支付的支付通知
        /// </summary>
        /// <returns></returns>
        private bool IsSuccessResult()
        {
            if (string.Compare(GatewayData.GetStringValue(Constant.RETURN_CODE), SUCCESS) == 0 &&
                string.Compare(GatewayData.GetStringValue(Constant.RESULT_CODE), SUCCESS) == 0 &&
                string.Compare(GatewayData.GetStringValue(Constant.SIGN), BuildSign()) == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 是否是已成功的返回
        /// </summary>
        /// <returns></returns>
        private bool IsSuccessReturn()
        {
            if (string.Compare(GatewayData.GetStringValue(Constant.RETURN_CODE), SUCCESS) == 0)
            {
                return true;
            }

            throw new Exception(GatewayData.GetStringValue(Constant.RETURN_MSG));
        }

        /// <summary>
        /// 检查查询结果
        /// </summary>
        /// <param name="resultXml">查询结果的XML</param>
        /// <returns></returns>
        private bool CheckQueryResult(string resultXml)
        {
            // 需要先清除之前查询订单的参数，否则会对接收到的参数造成干扰。
            ClearGatewayData();
            GatewayData.FromXml(resultXml);
            if (IsSuccessResult())
            {
                if (string.Compare(Order.OutTradeNo, GatewayData.GetStringValue(Constant.OUT_TRADE_NO)) == 0 &&
                   Order.Amount == GatewayData.GetIntValue(Constant.TOTAL_FEE) / 100.0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 初始化查询订单参数
        /// </summary>
        private void InitQueryOrderParameter()
        {
            GatewayData.Add(Constant.MCH_ID, Merchant.MchId);
            GatewayData.Add(Constant.OUT_TRADE_NO, Order.OutTradeNo);
            GatewayData.Add(Constant.NONCE_STR, Merchant.NonceStr);
            GatewayData.Add(Constant.SIGN, BuildSign());    // 签名需要在最后设置，以免缺少参数。
        }

        /// <summary>
        /// 清除网关的数据
        /// </summary>
        private void ClearGatewayData()
        {
            GatewayData.Clear();
        }

        /// <summary>
        /// 初始化表示已成功接收到支付通知的数据
        /// </summary>
        private void InitProcessSuccessParameter()
        {
            GatewayData.Add(Constant.RETURN_CODE, SUCCESS);
        }

        public override void WriteSuccessFlag()
        {
            // 需要先清除之前接收到的通知的参数，否则会对生成标志成功接收到通知的XML造成干扰。
            ClearGatewayData();
            InitProcessSuccessParameter();
            HttpUtil.Write(GatewayData.ToXml());
        }

        #endregion
    }
}
