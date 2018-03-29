using ICanPay.Alipay.Response;

namespace ICanPay.Alipay.Request
{
    public class WapPayRequest : BaseRequest<WapPayResponse>
    {
        public WapPayRequest()
            : base("alipay.trade.wap.pay")
        {
        }
    }
}
