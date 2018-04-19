using PaySharp.Wechatpay.Domain;
using PaySharp.Wechatpay.Response;

namespace PaySharp.Wechatpay.Request
{
    public class CancelRequest : BaseRequest<CancelModel, CancelResponse>
    {
        public CancelRequest()
        {
            RequestUrl = "/secapi/pay/reverse";
            IsUseCert = true;
        }

        internal override void Execute(Merchant merchant)
        {
            GatewayData.Remove("notify_url");
        }
    }
}
