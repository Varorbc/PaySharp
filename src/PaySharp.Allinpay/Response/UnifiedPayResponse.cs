using PaySharp.Core.Request;

namespace PaySharp.Allinpay.Response
{
    public class UnifiedPayResponse : BaseResponse
    {
        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
