using ICanPay.Alipay.Response;
using ICanPay.Core.Request;
using ICanPay.Core.Utils;

namespace ICanPay.Alipay.Request
{
    public class BaseRequest : Request<QueryResponse>
    {
        public BaseRequest(string method)
        {
            RequestUrl = "/gateway.do?charset=UTF-8";
            GatewayData.Add(Constant.METHOD, method);
        }

        public override void AddGatewayData(object obj)
        {
            base.AddGatewayData(obj);

            GatewayData.Add(Constant.BIZ_CONTENT, Util.SerializeObject(obj));
        }
    }
}
