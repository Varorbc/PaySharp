using ICanPay.Alipay.Response;

namespace ICanPay.Alipay.Request
{
    public class RefundRequest : BaseRequest<RefundResponse>
    {
        public RefundRequest()
            : base("alipay.trade.refund")
        {
        }
    }
}
