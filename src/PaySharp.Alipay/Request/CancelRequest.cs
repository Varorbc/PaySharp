using PaySharp.Alipay.Domain;
using PaySharp.Alipay.Response;

namespace PaySharp.Alipay.Request
{
    public class CancelRequest : BaseRequest<CancelModel, CancelResponse>
    {
        public CancelRequest()
            : base("alipay.trade.cancel")
        {
        }
    }
}
