using PaySharp.Qpay.Domain;
using PaySharp.Qpay.Response;

namespace PaySharp.Qpay.Request
{
    public class RefundQueryRequest : BaseRequest<RefundQueryModel, RefundQueryResponse>
    {
        public RefundQueryRequest()
        {
            RequestUrl = "/cgi-bin/pay/qpay_refund_query.cgi";
        }

        internal override void Execute(Merchant merchant)
        {
            GatewayData.Remove("notify_url");
        }
    }
}
