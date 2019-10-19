using System;
using PaySharp.Core.Request;
using PaySharp.Core.Response;
using PaySharp.Core.Utils;

namespace PaySharp.Unionpay.Request
{
    public class BaseRequest<TModel, TResponse> : Request<TModel, TResponse> where TResponse : IResponse
    {
        public BaseRequest()
            : base(StringComparer.Ordinal)
        {
        }

        public override void AddGatewayData(TModel model)
        {
            base.AddGatewayData(model);

            GatewayData.Add(model, StringCase.Camel);
        }

        internal virtual void Execute(Merchant merchant)
        {
        }
    }
}
