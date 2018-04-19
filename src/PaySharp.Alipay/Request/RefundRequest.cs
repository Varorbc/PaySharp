using PaySharp.Alipay.Domain;
using PaySharp.Alipay.Response;

namespace PaySharp.Alipay.Request
{
    public class RefundRequest : BaseRequest<RefundModel, RefundResponse>
    {
        public RefundRequest()
            : base("alipay.trade.refund")
        {
        }
    }
}
