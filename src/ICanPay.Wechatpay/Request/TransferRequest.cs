using ICanPay.Wechatpay.Domain;
using ICanPay.Wechatpay.Response;

namespace ICanPay.Wechatpay.Request
{
    public class TransferRequest : BaseRequest<TransferModel, TransferResponse>
    {
        public TransferRequest()
        {
            RequestUrl = "/mmpaymkttransfers/promotion/transfers";
            IsUseCert = true;
        }
    }
}
