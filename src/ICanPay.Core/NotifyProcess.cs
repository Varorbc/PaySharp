using System.Collections.Generic;
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
        static string[] yeepayGatewayVerifyParmaNames = { "r0_Cmd", "r1_Code", "r2_TrxId", "r3_Amt", "r4_Cur", "r5_Pid", "r6_Order" };
        static string[] tenpayGatewayVerifyParmaNames = { "trade_mode", "trade_state", "transaction_id", "notify_id", "total_fee", "fee_type" };
        static string[] alipayGatewayVerifyParmaNames = { "notify_type", "notify_id", "notify_time", "sign", "sign_type" };
        static string[] wechatpayGatewayVerifyParmaNames = { "return_code", "appid", "mch_id", "nonce_str", "result_code" };

        #endregion

        #region 方法

        /// <summary>
        /// 验证网关的类型
        /// </summary>
        public static GatewayBase GetGateway(ICollection<GatewayBase> gatewayList)
        {
            var gatewayData = ReadNotifyData();
            if (IsAlipayGateway(gatewayData))
            {
                var gateway = gatewayList.GetGateway(GatewayType.Alipay);
                gateway.GatewayData = gatewayData;
                return gateway;
            }

            if (IsWechatpayGateway(gatewayData))
            {
                var gateway = gatewayList.GetGateway(GatewayType.Wechatpay);
                gateway.GatewayData = gatewayData;
                return gateway;
            }

            if (IsTenpayGateway(gatewayData))
            {
                var gateway = gatewayList.GetGateway(GatewayType.Tenpay);
                gateway.GatewayData = gatewayData;
                return gateway;
            }

            if (IsYeepayGateway(gatewayData))
            {
                var gateway = gatewayList.GetGateway(GatewayType.Yeepay);
                gateway.GatewayData = gatewayData;
                return gateway;
            }

            return new NullGateway(gatewayData);
        }

        /// <summary>
        /// 验证是否是易宝网关
        /// </summary>
        /// <param name="gatewayData">网关数据</param>
        /// <returns></returns>
        private static bool IsYeepayGateway(GatewayData gatewayData)
        {
            return ExistParameter(yeepayGatewayVerifyParmaNames, gatewayData);
        }

        /// <summary>
        /// 是否是财付通网关
        /// </summary>
        /// <param name="gatewayData">网关数据</param>
        /// <returns></returns>
        private static bool IsTenpayGateway(GatewayData gatewayData)
        {
            return ExistParameter(tenpayGatewayVerifyParmaNames, gatewayData);
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
        private static bool IsXmlData => string.Compare(HttpUtil.UserAgent, "text/xml") == 0;

        /// <summary>
        /// 是否是GET请求
        /// </summary>
        /// <returns></returns>
        private static bool IsGetRequest => string.Compare(HttpUtil.RequestType, "GET") == 0;

        #endregion

    }
}
