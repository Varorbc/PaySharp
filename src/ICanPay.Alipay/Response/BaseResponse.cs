using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ICanPay.Alipay.Response
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class BaseResponse
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
    }
}
