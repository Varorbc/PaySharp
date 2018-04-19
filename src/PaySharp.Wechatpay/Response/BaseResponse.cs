using PaySharp.Core;
using PaySharp.Core.Request;
using PaySharp.Core.Response;

namespace PaySharp.Wechatpay.Response
{
    public abstract class BaseResponse : IResponse
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        [ReName(Name = "appid")]
        public string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string MchId { get; set; }

        /// <summary>
        /// 设备号
        /// </summary>
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// 业务结果
        /// </summary>
        public string ResultCode { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public string ErrCode { get; set; }

        /// <summary>
        /// 错误代码描述
        /// </summary>
        public string ErrCodeDes { get; set; }

        /// <summary>
        /// 返回状态码
        /// </summary>
        public string ReturnCode { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string ReturnMsg { get; set; }

        /// <summary>
        /// 原始值
        /// </summary>
        public string Raw { get; set; }

        internal GatewayData GatewayData { get; set; }

        internal abstract void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request) where TResponse : IResponse;
    }
}
