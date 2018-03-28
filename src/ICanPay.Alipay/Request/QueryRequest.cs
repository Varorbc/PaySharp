using ICanPay.Alipay.Response;
using ICanPay.Core.Request;
using ICanPay.Core.Utils;

namespace ICanPay.Alipay.Request
{
    public class QueryRequest : Request<QueryResponse>
    {
        public QueryRequest()
        {
            RequestUrl = "/gateway.do";
            GatewayData.Add(Constant.METHOD, Constant.QUERY);
        }

        public override void AddGatewayData(object obj)
        {
            base.AddGatewayData(obj);

            GatewayData.Add(Constant.BIZ_CONTENT, Util.SerializeObject(obj));
        }
    }
}
