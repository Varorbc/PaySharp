using ICanPay.Alipay.Domain;
using ICanPay.Alipay.Response;

namespace ICanPay.Alipay.Request
{
    public class AppPayRequest : BaseRequest<AppPayModel, AppPayResponse>
    {
        public AppPayRequest()
            : base("alipay.trade.app.pay")
        {
        }
    }
}
