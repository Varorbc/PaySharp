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
            GatewayData.Add(Constant.METHOD, method);
        }

        public override void AddGatewayData(TModel model)
        {
            base.AddGatewayData(model);

            GatewayData.Add(Constant.BIZ_CONTENT, Util.SerializeObject(model));
        }
    }
}
