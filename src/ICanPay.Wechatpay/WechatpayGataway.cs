using ICanPay.Core;
using System;
using System.Threading.Tasks;

namespace ICanPay.Wechatpay
{
    /// <summary>
    /// 微信支付网关
    /// </summary>
    public sealed class WechatpayGataway : GatewayBase, IPaymentQRCode, IQueryNow, IPaymentApp, IPaymentUrl
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

        public new Notify Notify => (Notify)base.Notify;

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
            return null;//GetWeixinPaymentUrl(UnifiedOrder());
        }

        public string BuildPaymentApp()
        {
            UnifiedOrder();
            InitAppParameter();
            return GatewayData.ToUrlEncode();
        }

        public string BuildPaymentUrl()
        {
            UnifiedOrder();
            return Notify.MWebUrl;
        }

        protected override void InitOrderParameter()
        {
            base.InitOrderParameter();

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
            GatewayData.Add(Constant.TRADE_TYPE, Order.TradeType);
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

            #endregion

            GatewayData.Add(Constant.SIGN, BuildSign());
        }

        protected override void SupplementaryAppParameter()
        {
            if (!string.IsNullOrEmpty(Order.SceneInfo))
            {
                GatewayData.Add(Constant.SCENE_INFO, Order.SceneInfo);
            }

            Order.TradeType = Constant.APP;
            Order.SpbillCreateIp = HttpUtil.RemoteIpAddress.ToString();
        }

        protected override void SupplementaryWebParameter()
        {
            Order.SpbillCreateIp = HttpUtil.RemoteIpAddress.ToString();
        }

        protected override void SupplementaryWapParameter()
        {
            if (!string.IsNullOrEmpty(Order.SceneInfo))
            {
                GatewayData.Add(Constant.SCENE_INFO, Order.SceneInfo);
            }
            else
            {
                throw new ArgumentNullException("SceneInfo 参数不可为空");
            }

            Order.TradeType = Constant.MWEB;
            Order.SpbillCreateIp = HttpUtil.RemoteIpAddress.ToString();
        }

        protected override void SupplementaryScanParameter()
        {
            Order.SpbillCreateIp = HttpUtil.LocalIpAddress.ToString();
        }

        public bool QueryNow()
        {
            return CheckQueryResult(QueryOrder());
        }

        /// <summary>
        /// 统一下单
        /// </summary>
        /// <returns></returns>
        private void UnifiedOrder()
        {
            InitOrderParameter();
            string result = HttpUtil
                .PostAsync(GatewayUrl, GatewayData.ToXml())
                .GetAwaiter()
                .GetResult();
            ReadReturnResult(result);
        }

        private string QueryOrder()
        {
            InitQueryOrderParameter();
            return HttpUtil
                .PostAsync(queryGatewayUrl, GatewayData.ToXml())
                .GetAwaiter()
                .GetResult();
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
        /// 获得微信支付的URL
        /// </summary>
        /// <param name="resultXml">创建订单返回的数据</param>
        /// <returns></returns>
        private string GetWeixinPaymentUrl(string resultXml)
        {
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
        private void IsSuccessReturn()
        {
            if (Notify.ReturnCode == FAIL)
            {
                throw new Exception(Notify.ReturnMsg);
            }
        }

        /// <summary>
        /// 检查查询结果
        /// </summary>
        /// <param name="resultXml">查询结果的XML</param>
        /// <returns></returns>
        private bool CheckQueryResult(string resultXml)
        {
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
            GatewayData.Add(Constant.SIGN, BuildSign());
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
            GatewayData.Add(Constant.PREPAYID, "23");
            GatewayData.Add(Constant.PACKAGE, "Sign=WXPay");
            GatewayData.Add(Constant.NONCE_STR, Merchant.NonceStr);
            GatewayData.Add(Constant.TIMESTAMP, DateTime.Now.ToTimeStamp());
            GatewayData.Add(Constant.SIGN, BuildSign());
        }

        public override void WriteSuccessFlag()
        {
            GatewayData.Add(Constant.RETURN_CODE, SUCCESS);
            HttpUtil.Write(GatewayData.ToXml());
        }

        #endregion
    }
}
