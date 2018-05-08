using PaySharp.Qpay.Domain;
using PaySharp.Qpay.Response;

namespace PaySharp.Qpay.Request
{
    public class QueryRequest : BaseRequest<QueryModel, QueryResponse>
    {
        public QueryRequest()
        {
            RequestUrl = "/cgi-bin/pay/qpay_order_query.cgi";
        }

        internal override void Execute(Merchant merchant)
        {
            GatewayData.Remove("notify_url");
        }
    }
}
