using PaySharp.Core.Request;

namespace PaySharp.Wechatpay.Response
{
    public class ScanPayResponse : BaseResponse
    {
        /// <summary>
        /// 交易类型
        /// </summary>
        public string TradeType { get; set; }

        /// <summary>
        /// 微信生成的预支付回话标识，用于后续接口调用中使用，该值有效期为2小时
        /// </summary>
        public string PrepayId { get; set; }

        /// <summary>
        /// 二维码链接
        /// </summary>
        public string CodeUrl { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
