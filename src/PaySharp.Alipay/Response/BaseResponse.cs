using PaySharp.Core.Request;
using PaySharp.Core.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PaySharp.Alipay.Response
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public abstract class BaseResponse : IResponse
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
        [JsonProperty("msg")]
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
        [JsonProperty("sub_msg")]
        public string SubMessage { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// 原始值
        /// </summary>
        public string Raw { get; set; }

        internal abstract void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request) where TResponse : IResponse;
    }
}
