using PaySharp.Core.Utils;
using PaySharp.Wechatpay.Response;

namespace PaySharp.Wechatpay.Request
{
    public class PublicKeyRequest : BaseRequest<object, PublicKeyResponse>
    {
        public PublicKeyRequest()
        {
            RequestUrl = "https://fraud.mch.weixin.qq.com/risk/getpublickey";
            IsUseCert = true;
        }

        internal override void Execute(Merchant merchant)
        {
            GatewayData.Remove("appid");
            GatewayData.Remove("notify_url");
            GatewayData.Add("nonce_str", Util.GenerateNonceStr());
        }
    }
}
