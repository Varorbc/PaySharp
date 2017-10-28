using System.IO;

namespace ICanPay.Core
{
    /// <summary>
    /// 网关通知的处理类，通过对返回数据的分析识别网关类型
    /// </summary>
    internal static class NotifyProcess
    {

        #region 私有字段

        // 需要验证的参数名称数组，用于识别不同的网关类型。
        // 检查是否在发回的数据中，需要保证参数名称跟其他各个网关验证的参数名称不重复。
        // 建议使用网关中返回的不为空的参数名，并使用尽可能多的参数名。
        private static string[] alipayGatewayVerifyParmaNames = { "notify_type", "notify_id", "notify_time", "sign", "sign_type" };
        private static string[] wechatpayGatewayVerifyParmaNames = { "return_code", "appid", "mch_id", "nonce_str", "result_code" };

        #endregion

        #region 方法

        /// <summary>
        /// 获取网关
        /// </summary>
        /// <param name="gateways">网关列表</param>
        /// <returns></returns>
        public static GatewayBase GetGateway(IGateways gateways)
        {
            var gatewayData = ReadNotifyData();
            GatewayBase gateway;

            if (IsAlipayGateway(gatewayData))
            {
                gateway = gateways.Get(GatewayType.Alipay);
            }
            else if (IsWechatpayGateway(gatewayData))
            {
                gateway = gateways.Get(GatewayType.Wechatpay);
            }
            else
            {
                gateway = new NullGateway();
            }

            gateway.GatewayData = gatewayData;
            return gateway;
        }

        /// <summary>
        /// 是否是支付宝网关
        /// </summary>
        /// <param name="gatewayData">网关数据</param>
        /// <returns></returns>
        private static bool IsAlipayGateway(GatewayData gatewayData)
        {
            return ExistParameter(alipayGatewayVerifyParmaNames, gatewayData);
        }

        /// <summary>
        /// 是否是微信支付网关
        /// </summary>
        /// <param name="gatewayData">网关数据</param>
        /// <returns></returns>
        private static bool IsWechatpayGateway(GatewayData gatewayData)
        {
            return ExistParameter(wechatpayGatewayVerifyParmaNames, gatewayData);
        }

        /// <summary>
        /// 网关参数数据项中是否存在指定的所有参数名
        /// </summary>
        /// <param name="parmaName">参数名数组</param>
        /// <param name="gatewayData">网关数据</param>
        public static bool ExistParameter(string[] parmaName, GatewayData gatewayData)
        {
            int compareCount = 0;
            foreach (var item in parmaName)
            {
                if (gatewayData.Exists(item))
                {
                    compareCount++;
                }
            }

            if (compareCount == parmaName.Length)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 读取网关发回的数据
        /// </summary>
        /// <returns></returns>
        public static GatewayData ReadNotifyData()
        {
            var gatewayData = new GatewayData();
            if (IsGetRequest)
            {
                gatewayData.FromUrl(HttpUtil.QueryString);
            }
            else
            {
                if (IsXmlData)
                {
                    var reader = new StreamReader(HttpUtil.Body);
                    string xmlData = reader.ReadToEnd();
                    reader.Dispose();
                    gatewayData.FromXml(xmlData);
                }
                else
                {
                    gatewayData.FromForm(HttpUtil.Form);
                }
            }

            return gatewayData;
        }

        /// <summary>
        /// 是否是Xml格式数据
        /// </summary>
        /// <returns></returns>
        private static bool IsXmlData => HttpUtil.ContentType == "text/xml" || HttpUtil.ContentType == "application/xml";

        /// <summary>
        /// 是否是GET请求
        /// </summary>
        /// <returns></returns>
        private static bool IsGetRequest => HttpUtil.RequestType == "GET";

        #endregion

    }
}
