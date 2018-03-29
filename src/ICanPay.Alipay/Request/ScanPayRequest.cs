using ICanPay.Alipay.Response;

namespace ICanPay.Alipay.Request
{
    public class ScanPayRequest : BaseRequest<ScanPayResponse>
    {
        public ScanPayRequest()
            : base("alipay.trade.precreate")
        {
        }
    }
}
