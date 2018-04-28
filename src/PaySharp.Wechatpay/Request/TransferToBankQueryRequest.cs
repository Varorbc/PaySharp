using PaySharp.Wechatpay.Domain;
using PaySharp.Wechatpay.Response;

namespace PaySharp.Wechatpay.Request
{
    public class TransferToBankQueryRequest : BaseRequest<TransferToBankQueryModel, TransferToBankQueryResponse>
    {
        public TransferToBankQueryRequest()
        {
            RequestUrl = "/mmpaysptrans/query_bank";
            IsUseCert = true;
        }

        internal override void Execute(Merchant merchant)
        {
            GatewayData.Remove("notify_url");
            GatewayData.Remove("appid");
            GatewayData.Remove("sign_type");
        }
    }
}
