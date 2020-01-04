using PaySharp.Netpay.Domain;
using PaySharp.Netpay.Response;

namespace PaySharp.Netpay.Request
{
    public class QueryRequest : BaseRequest<QueryModel, QueryResponse>
    {
        internal override void Execute(Merchant merchant)
        {
            GatewayData.Remove("notifyUrl");
        }
    }
}
