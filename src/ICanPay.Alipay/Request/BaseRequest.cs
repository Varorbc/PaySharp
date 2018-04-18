using ICanPay.Core.Request;
using ICanPay.Core.Response;
using ICanPay.Core.Utils;

namespace ICanPay.Alipay.Request
{
    public class BaseRequest<TModel, TResponse> : Request<TModel, TResponse> where TResponse : IResponse
    {
        public BaseRequest(string method)
        {
            RequestUrl = "/gateway.do?charset=UTF-8";
            GatewayData.Add("method", method);
        }

        public override void AddGatewayData(TModel model)
        {
            base.AddGatewayData(model);

            GatewayData.Add("biz_content", Util.SerializeObject(model));
        }
    }
}
