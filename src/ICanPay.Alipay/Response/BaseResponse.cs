using ICanPay.Core.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ICanPay.Alipay.Response
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class BaseResponse : IResponse
    {
        /// <summary>
        /// 网关返回码,详见文档
        /// https://docs.open.alipay.com/common/105806
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 网关返回码描述,详见文档
        /// https://docs.open.alipay.com/common/105806
        /// </summary>
        [JsonProperty(PropertyName = Constant.MSG)]
        public string Message { get; set; }

        /// <summary>
        /// 网关返回码,详见文档
        /// https://docs.open.alipay.com/common/105806
        /// </summary>
        public string SubCode { get; set; }

        /// <summary>
        /// 网关返回码描述,详见文档
        /// https://docs.open.alipay.com/common/105806
        /// </summary>
        [JsonProperty(PropertyName = Constant.SUBMSG)]
        public string SubMessage { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// 原始值
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 支付宝交易号
        /// </summary>
        public string TradeNo { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }
    }
}
