using ICanPay.Wechatpay.Domain;
using ICanPay.Wechatpay.Response;

namespace ICanPay.Wechatpay.Request
{
    public class CloseRequest : BaseRequest<CloseModel, CloseResponse>
    {
        public CloseRequest()
        {
            RequestUrl = "/pay/closeorder";
        }
    }
}
