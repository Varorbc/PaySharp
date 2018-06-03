using PaySharp.Unionpay.Domain;
using PaySharp.Unionpay.Response;

namespace PaySharp.Unionpay.Request
{
    public class RefundRequest : BaseRequest<RefundModel, RefundResponse>
    {
        public RefundRequest()
        {
            RequestUrl = "/gateway/api/backTransReq.do";
        }

        internal override void Execute(Merchant merchant)
        {
            GatewayData.Remove("frontUrl");
        }
    }
}
