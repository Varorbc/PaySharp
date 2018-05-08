using PaySharp.Core.Request;

namespace PaySharp.Qpay.Response
{
    public class CloseResponse : BaseResponse
    {
        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
