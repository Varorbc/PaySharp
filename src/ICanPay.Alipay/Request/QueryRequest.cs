using ICanPay.Alipay.Domain;
using ICanPay.Alipay.Response;

namespace ICanPay.Alipay.Request
{
    public class QueryRequest : BaseRequest<QueryModel, QueryResponse>
    {
        public QueryRequest()
            : base("alipay.trade.query")
        {
        }
    }
}
