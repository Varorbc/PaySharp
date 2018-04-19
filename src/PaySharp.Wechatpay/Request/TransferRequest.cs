using PaySharp.Wechatpay.Domain;
using PaySharp.Wechatpay.Response;

namespace PaySharp.Wechatpay.Request
{
    public class TransferRequest : BaseRequest<TransferModel, TransferResponse>
    {
        public TransferRequest()
        {
            RequestUrl = "/mmpaymkttransfers/promotion/transfers";
            IsUseCert = true;
        }

        internal override void Execute(Merchant merchant)
        {
            GatewayData.Add("mch_appid", merchant.AppId);
            GatewayData.Add("mchid", merchant.MchId);

            GatewayData.Remove("appid");
            GatewayData.Remove("mch_id");
            GatewayData.Remove("notify_url");
            GatewayData.Remove("sign_type");
        }
    }
}
