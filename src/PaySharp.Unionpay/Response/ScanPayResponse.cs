using PaySharp.Core.Request;

namespace PaySharp.Unionpay.Response
{
    public class ScanPayResponse : BaseResponse
    {
        /// <summary>
        /// 二维码
        /// </summary>
        public string QrCode { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
