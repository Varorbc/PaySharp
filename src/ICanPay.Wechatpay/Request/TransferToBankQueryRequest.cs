using ICanPay.Wechatpay.Domain;
using ICanPay.Wechatpay.Response;

namespace ICanPay.Wechatpay.Request
{
    public class TransferToBankQueryRequest : BaseRequest<TransferToBankQueryModel, TransferToBankQueryResponse>
    {
        public TransferToBankQueryRequest()
        {
            RequestUrl = "/mmpaysptrans/query_bank";
            IsUseCert = true;
        }

        internal override void Execute()
        {
            GatewayData.Remove("notify_url");
        }
    }
}
