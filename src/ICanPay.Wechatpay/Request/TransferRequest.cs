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

        internal override void Execute()
        {
            GatewayData.Remove("notify_url");
            string appId = GatewayData.GetStringValue("appid");
            GatewayData.Remove("appid");
            GatewayData.Add("mch_appid", appId);
        }
    }
}
