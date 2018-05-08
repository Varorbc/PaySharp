using PaySharp.Qpay.Domain;
using PaySharp.Qpay.Response;

namespace PaySharp.Qpay.Request
{
    public class CloseRequest : BaseRequest<CloseModel, CloseResponse>
    {
        public CloseRequest()
        {
            RequestUrl = "/cgi-bin/pay/qpay_close_order.cgi";
        }

        internal override void Execute(Merchant merchant)
        {
            GatewayData.Remove("notify_url");
        }
    }
}
