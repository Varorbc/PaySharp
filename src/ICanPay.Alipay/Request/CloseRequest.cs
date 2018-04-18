using ICanPay.Alipay.Domain;
using ICanPay.Alipay.Response;

namespace ICanPay.Alipay.Request
{
    public class CloseRequest : BaseRequest<CloseModel, CloseResponse>
    {
        public CloseRequest()
            : base("alipay.trade.close")
        {
        }
    }
}
