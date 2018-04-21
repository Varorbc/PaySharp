using PaySharp.Core.Request;

namespace PaySharp.Unionpay.Response
{
    public class AppPayResponse : BaseResponse
    {
        /// <summary>
        /// 银联受理订单号
        /// </summary>
        public string Tn { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
