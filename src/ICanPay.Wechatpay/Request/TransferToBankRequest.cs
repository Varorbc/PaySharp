using ICanPay.Wechatpay.Domain;
using ICanPay.Wechatpay.Response;

namespace ICanPay.Wechatpay.Request
{
    public class TransferToBankRequest : BaseRequest<TransferToBankModel, TransferToBankResponse>
    {
        public TransferToBankRequest()
        {
            RequestUrl = "/mmpaysptrans/pay_bank";
            IsUseCert = true;
        }

        internal override void Execute(Merchant merchant)
        {
            GatewayData.Remove("notify_url");
        }
    }
}
