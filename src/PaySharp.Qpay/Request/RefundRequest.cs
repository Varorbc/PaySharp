using PaySharp.Qpay.Domain;
using PaySharp.Qpay.Response;

namespace PaySharp.Qpay.Request
{
    public class RefundRequest : BaseRequest<RefundModel, RefundResponse>
    {
        public RefundRequest()
        {
            RequestUrl = "https://api.qpay.qq.com/cgi-bin/pay/qpay_refund.cgi";
            IsUseCert = true;
        }

        internal override void Execute(Merchant merchant)
        {
            GatewayData.Remove("notify_url");
        }
    }
}
