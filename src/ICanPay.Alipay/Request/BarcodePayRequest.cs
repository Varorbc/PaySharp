using ICanPay.Alipay.Response;

namespace ICanPay.Alipay.Request
{
    public class BarcodePayRequest : BaseRequest<BarcodePayResponse>
    {
        public BarcodePayRequest()
            : base("alipay.trade.pay")
        {
        }
    }
}
