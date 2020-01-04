using PaySharp.Core.Request;

namespace PaySharp.Netpay.Response
{
    public class UnifiedPayResponse : BaseResponse
    {
        /// <summary>
        /// JSAPI支付用的请求报文，带有签名信息
        /// </summary>
        public string JsPayRequest { get; set; }

        /// <summary>
        /// APP支付用的请求报文，带有签名信息
        /// </summary>
        public string AppPayRequest { get; set; }

        /// <summary>
        /// 支付ID，用于APP支付和公众号支付
        /// </summary>
        public string PrepayId { get; set; }

        /// <summary>
        /// 支付二维码，内容为URL，由终端转换成二维码显示
        /// </summary>
        public string QrCode { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
