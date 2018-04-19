using PaySharp.Alipay.Domain;
using PaySharp.Alipay.Response;

namespace PaySharp.Alipay.Request
{
    public class WebPayRequest : BaseRequest<WebPayModel, WebPayResponse>
    {
        public WebPayRequest()
            : base("alipay.trade.page.pay")
        {
        }
    }
}
