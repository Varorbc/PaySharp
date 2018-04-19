using PaySharp.Core.Request;
using PaySharp.Core.Response;

namespace PaySharp.Core
{
    public interface IGateway
    {
        TResponse Execute<TModel, TResponse>(Request<TModel, TResponse> request) where TResponse : IResponse;
    }
}
