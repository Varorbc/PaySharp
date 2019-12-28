using PaySharp.Allinpay.Domain;
using PaySharp.Allinpay.Response;

namespace PaySharp.Allinpay.Request
{
    public class QueryRequest : BaseRequest<QueryModel, QueryResponse>
    {
        public QueryRequest()
        {
            RequestUrl = "/apiweb/unitorder/query";
        }

        internal override void Execute(Merchant merchant)
        {
            GatewayData.Remove("notify_url");
        }
    }
}
