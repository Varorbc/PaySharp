using ICanPay.Core;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ICanPay.Tenpay
{
    /// <summary>
    /// 财付通网关
    /// </summary>
    public sealed class TenpayGateway : GatewayBase, IPaymentUrl, IPaymentForm, IQueryNow
    {

        #region 私有字段

        const string payGatewayUrl = "https://gw.tenpay.com/gateway/pay.htm";
        const string verifyNotifyGatewayUrl = "https://gw.tenpay.com/gateway/verifynotifyid.xml";
        const string queryGatewayUrl = "https://gw.tenpay.com/gateway/normalorderquery.xml";
        static Encoding pageEncoding = Encoding.GetEncoding("GB2312");

        #endregion


        #region 构造函数

        /// <summary>
        /// 初始化财付通网关
        /// </summary>
        public TenpayGateway()
        {
        }


        /// <summary>
        /// 初始化财付通网关
        /// </summary>
        /// <param name="gatewayData">网关数据</param>
        public TenpayGateway(GatewayData gatewayData)
            : base(gatewayData)
        {
        }

        #endregion


        #region 属性

        /// <summary>
        /// 网关名称
        /// </summary>
        public override GatewayType GatewayType
        {
            get
            {
                return GatewayType.Tenpay;
            }
        }

        public override string GatewayUrl { get; set; }

        #endregion


        #region 方法

        /// <summary>
        /// 支付订单数据的Url
        /// </summary>
        public string BuildPaymentUrl()
        {
            InitOrderParameter();
            return string.Format("{0}?{1}", payGatewayUrl, GetPaymentQueryString());
        }


        public string BuildPaymentForm()
        {
            InitOrderParameter();
            return GatewayData.ToForm(payGatewayUrl);
        }


        /// <summary>
        /// 初始化订单参数
        /// </summary>
        protected override void InitOrderParameter()
        {
            //GatewayData.Add("body", Order.Subject);
            //GatewayData.Add("fee_type", "1");
            //GatewayData.Add("notify_url", Merchant.NotifyUrl);
            //GatewayData.Add("out_trade_no", Order.Id);
            //GatewayData.Add("partner", Merchant.UserName);
            //GatewayData.Add("return_url", Merchant.NotifyUrl);
            //GatewayData.Add("spbill_create_ip", HttpContext.Current.Request.Host.Value);
            //GatewayData.Add("total_fee", Order.Amount * 100);
            //GatewayData.Add("input_charset", "GBK");
            //GatewayData.Add("sign", GetOrderSign());    // 签名需要在最后设置，以免缺少参数。
        }


        private string GetPaymentQueryString()
        {
            StringBuilder url = new StringBuilder();
            foreach (var item in GatewayData.Values)
            {
                url.AppendFormat("{0}={1}&", item.Key, item.Value);
            }

            return url.ToString().TrimEnd('&');
        }


        private string GetOrderSign()
        {
            StringBuilder signParameterBuilder = new StringBuilder();
            foreach (var item in GatewayData.Values)
            {
                // 空值的参数跟sign签名参数不参加签名
                if (string.Compare(item.Key, "sign") != 0)
                {
                    signParameterBuilder.AppendFormat("{0}={1}&", item.Key, item.Value);
                }
            }

            // 获得MD5值时需要使用GB2312编码，否则主题中有中文时会提示签名异常
            //return Utility.GetMD5(signParameterBuilder.Append("key=" + Merchant.Key).ToString(), pageEncoding);
            return null;
        }


        /// <summary>
        /// 验证订单是否支付成功
        /// </summary>
        /// <remarks>这里处理查询订单的网关通知跟支付订单的网关通知</remarks>
        protected override async Task<bool> CheckNotifyDataAsync()
        {
            if (IsSuccessResult())
            {
                ReadNotifyOrder();
                return true;
            }

            return false;
        }


        /// <summary>
        /// 是否是已成功支付的支付通知
        /// </summary>
        /// <returns></returns>
        private bool IsSuccessResult()
        {
            if (ValidateNotifyParameter())
            {
                if (ValidateNotifyId())
                {
                    return true;
                }
            }

            return false;
        }


        /// <summary>
        /// 检查支付通知，是否支付成功，货币类型是否为RMB，签名是否正确。
        /// </summary>
        /// <returns></returns>
        private bool ValidateNotifyParameter()
        {
            if (string.Compare(GatewayData.GetStringValue("trade_state"), "0") == 0 &&
                string.Compare(GatewayData.GetStringValue("trade_mode"), "1") == 0 &&
                string.Compare(GatewayData.GetStringValue("fee_type"), "1") == 0 &&
                string.Compare(GatewayData.GetStringValue("sign"), GetOrderSign()) == 0)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// 读取通知中的订单金额、订单编号
        /// </summary>
        private void ReadNotifyOrder()
        {
            Order.Amount = GatewayData.GetDoubleValue("total_fee") * 0.01;
            Order.OutTradeNo = GatewayData.GetStringValue("out_trade_no");
        }

        /// <summary>
        /// 验证通知Id
        /// </summary>
        /// <returns></returns>
        private bool ValidateNotifyId()
        {
            string resultXml = HttpUtil.ReadPage(GetValidateNotifyUrl(), pageEncoding);
            // 需要先备份并清除之前接收到的网关的通知的数据，否者会对数据的验证造成干扰。
            GatewayData gatewayData = BackupAndClearGatewayData();
            ReadResultXml(resultXml);
            bool result = ValidateNotifyParameter();
            RestoreGatewayParameter(gatewayData);   // 验证通知Id后还原之前的通知的数据。

            return result;
        }


        /// <summary>
        /// 验证订单金额、订单号是否与之前的通知的金额、订单号相符
        /// </summary>
        /// <returns></returns>
        private bool ValidateOrder()
        {
            if (Order.Amount == GatewayData.GetDoubleValue("total_fee") * 0.01 &&
               string.Compare(Order.OutTradeNo, GatewayData.GetStringValue("out_trade_no")) == 0)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// 获得验证通知的URL
        /// </summary>
        /// <returns></returns>

        private string GetValidateNotifyUrl()
        {
            return null;
            //return string.Format("{0}?{1}&sign={2}", verifyNotifyGatewayUrl, GetValidateNotifyQueryString(),
            //                     Utility.GetMD5(GetValidateNotifyQueryString() + "&key=" + Merchant.Key, pageEncoding));
        }


        /// <summary>
        /// 获得验证通知的查询字符串
        /// </summary>
        /// <returns></returns>
        private string GetValidateNotifyQueryString()
        {
            return null;
            //return string.Format("notify_id={0}&partner={1}", GatewayData.GetValue("notify_id"), Merchant.UserName);
        }


        /// <summary>
        /// 读取结果的XML
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private void ReadResultXml(string xml)
        {
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.LoadXml(xml);
            }
            catch (XmlException) { }

            foreach (XmlNode rootNode in xmlDocument.ChildNodes)
            {
                foreach (XmlNode item in rootNode.ChildNodes)
                {
                    GatewayData.Add(item.Name, item.InnerText);
                }
            }
        }


        /// <summary>
        /// 备份并清除网关的参数
        /// </summary>
        private GatewayData BackupAndClearGatewayData()
        {
            GatewayData gatewayData = GatewayData;
            GatewayData.Clear();
            return gatewayData;
        }


        /// <summary>
        /// 还原网关的参数
        /// </summary>
        /// <param name="gatewayData">网关数据</param>
        private void RestoreGatewayParameter(GatewayData gatewayData)
        {
            GatewayData = gatewayData;
        }


        public bool QueryNow()
        {
            ReadResultXml(HttpUtil.ReadPage(GetQueryOrderUrl(), pageEncoding));
            if (ValidateNotifyParameter() && ValidateOrder())
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// 获得查询订单的Url
        /// </summary>
        /// <returns></returns>
        private string GetQueryOrderUrl()
        {
            return null;
            //return string.Format("{0}?{1}&sign={2}", queryGatewayUrl, GetQueryOrderQueryString(),
            //                     Utility.GetMD5(GetQueryOrderQueryString() + "&key=" + Merchant.Key, pageEncoding));
        }


        /// <summary>
        /// 获得查询订单的查询字符串
        /// </summary>
        /// <returns></returns>
        private string GetQueryOrderQueryString()
        {
            return null;
            //return string.Format("out_trade_no={0}&partner={1}", Order.Id, Merchant.UserName);
        }

        protected override void SupplementaryAppParameter()
        {
            throw new NotImplementedException();
        }

        protected override void SupplementaryWebParameter()
        {
            throw new NotImplementedException();
        }

        protected override void SupplementaryWapParameter()
        {
            throw new NotImplementedException();
        }

        protected override void SupplementaryScanParameter()
        {
            throw new NotImplementedException();
        }

        protected override void SupplementaryBarcodeParameter()
        {
            throw new NotImplementedException();
        }


        #endregion

    }
}
