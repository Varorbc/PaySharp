using PaySharp.Alipay.Domain;
using PaySharp.Alipay.Response;

namespace PaySharp.Alipay.Request
{
    public class RefundQueryRequest : BaseRequest<RefundQueryModel, RefundQueryResponse>
    {
        public RefundQueryRequest()
            : base("alipay.trade.fastpay.refund.query")
        {
        }
    }
}
