using PaySharp.Allinpay.Domain;
using PaySharp.Allinpay.Response;

namespace PaySharp.Allinpay.Request
{
    public class UnifiedPayRequest : BaseRequest<UnifiedPayModel, UnifiedPayResponse>
    {
        public UnifiedPayRequest()
        {
            RequestUrl = "/apiweb/unitorder/pay";
        }
    }
}
