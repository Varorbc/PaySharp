using ICanPay.Alipay.Response;

namespace ICanPay.Alipay.Request
{
    public class RefundQueryRequest : BaseRequest<RefundQueryResponse>
    {
        public RefundQueryRequest()
            : base("alipay.trade.fastpay.refund.query")
        {
        }
    }
}
