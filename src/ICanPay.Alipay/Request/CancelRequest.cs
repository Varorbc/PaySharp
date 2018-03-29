using ICanPay.Alipay.Response;

namespace ICanPay.Alipay.Request
{
    public class CancelRequest : BaseRequest<CancelResponse>
    {
        public CancelRequest()
            : base("alipay.trade.cancel")
        {
        }
    }
}
