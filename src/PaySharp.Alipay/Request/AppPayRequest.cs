using PaySharp.Alipay.Domain;
using PaySharp.Alipay.Response;

namespace PaySharp.Alipay.Request
{
    public class AppPayRequest : BaseRequest<AppPayModel, AppPayResponse>
    {
        public AppPayRequest()
            : base("alipay.trade.app.pay")
        {
        }
    }
}
