using ICanPay.Alipay.Request;

namespace ICanPay.Alipay.Response
{
    public class AppletPayResponse : AppPayResponse
    {
        public AppletPayResponse(AppPayRequest request)
            : base(request)
        {
        }
    }
}
