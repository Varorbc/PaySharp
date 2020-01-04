using PaySharp.Core.Request;
using PaySharp.Core.Response;
using PaySharp.Core.Utils;

namespace PaySharp.Netpay.Request
{
    public class BaseRequest<TModel, TResponse> : Request<TModel, TResponse> where TResponse : IResponse
    {
        public BaseRequest()
        {
            RequestUrl = "/netpay-route-server/api/";
        }

        public override void AddGatewayData(TModel model)
        {
            base.AddGatewayData(model);

            GatewayData.Add(model, StringCase.Camel);
        }

        internal virtual void Execute(Merchant merchant)
        {
            if (!string.IsNullOrEmpty(NotifyUrl))
            {
                GatewayData.Add("notifyUrl", NotifyUrl);
            }
        }
    }
}
