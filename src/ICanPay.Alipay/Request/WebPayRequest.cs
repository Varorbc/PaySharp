using ICanPay.Alipay.Response;

namespace ICanPay.Alipay.Request
{
    public class WebPayRequest : BaseRequest<WebPayResponse>
    {
        public WebPayRequest()
            : base("alipay.trade.page.pay")
        {
        }
    }
}
