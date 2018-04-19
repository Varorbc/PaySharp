using PaySharp.Wechatpay.Domain;
using PaySharp.Wechatpay.Response;

namespace PaySharp.Wechatpay.Request
{
    public class QueryRequest : BaseRequest<QueryModel, QueryResponse>
    {
        public QueryRequest()
        {
            RequestUrl = "/pay/orderquery";
        }

        internal override void Execute(Merchant merchant)
        {
            GatewayData.Remove("notify_url");
        }
    }
}
