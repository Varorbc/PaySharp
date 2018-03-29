using ICanPay.Alipay.Response;

namespace ICanPay.Alipay.Request
{
    public class CloseRequest : BaseRequest<CloseResponse>
    {
        public CloseRequest()
            : base("alipay.trade.close")
        {
        }
    }
}
