using ICanPay.Alipay.Response;

namespace ICanPay.Alipay.Request
{
    public class AppPayRequest : BaseRequest<AppPayResponse>
    {
        public AppPayRequest()
            : base("alipay.trade.app.pay")
        {
        }
    }
}
