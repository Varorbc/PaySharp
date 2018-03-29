using ICanPay.Alipay.Response;

namespace ICanPay.Alipay.Request
{
    public class QueryRequest : BaseRequest<QueryResponse>
    {
        public QueryRequest()
            : base("alipay.trade.query")
        {
        }
    }
}
