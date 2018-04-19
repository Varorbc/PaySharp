using PaySharp.Alipay.Domain;
using PaySharp.Alipay.Response;

namespace PaySharp.Alipay.Request
{
    public class ScanPayRequest : BaseRequest<ScanPayModel, ScanPayResponse>
    {
        public ScanPayRequest()
            : base("alipay.trade.precreate")
        {
        }
    }
}
