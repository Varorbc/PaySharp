using ICanPay.Wechatpay.Domain;
using ICanPay.Wechatpay.Response;

namespace ICanPay.Wechatpay.Request
{
    public class CancelRequest : BaseRequest<CancelModel, CancelResponse>
    {
        public CancelRequest()
        {
            RequestUrl = "/secapi/pay/reverse";
            IsUseCert = true;
        }

        internal override void Execute()
        {
            GatewayData.Remove("notify_url");
        }
    }
}
