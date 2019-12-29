using PaySharp.Core.Request;
using PaySharp.Core.Response;
using PaySharp.Core.Utils;

namespace PaySharp.Allinpay.Request
{
    public class BaseRequest<TModel, TResponse> : Request<TModel, TResponse> where TResponse : IResponse
    {
        public override void AddGatewayData(TModel model)
        {
            base.AddGatewayData(model);

            GatewayData.Add(model, StringCase.Lower);
        }

        internal virtual void Execute(Merchant merchant)
        {
            if (!string.IsNullOrEmpty(NotifyUrl))
            {
                GatewayData.Add("notify_url", NotifyUrl);
            }
        }
    }
}
