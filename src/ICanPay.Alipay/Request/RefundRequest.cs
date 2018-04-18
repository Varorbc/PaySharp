using ICanPay.Alipay.Domain;
using ICanPay.Alipay.Response;

namespace ICanPay.Alipay.Request
{
    public class RefundRequest : BaseRequest<RefundModel, RefundResponse>
    {
        public RefundRequest()
            : base("alipay.trade.refund")
        {
        }
    }
}
