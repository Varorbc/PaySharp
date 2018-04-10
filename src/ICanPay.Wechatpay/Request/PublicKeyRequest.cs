using ICanPay.Wechatpay.Response;

namespace ICanPay.Wechatpay.Request
{
    internal class PublicKeyRequest : BaseRequest<object, PublicKeyResponse>
    {
        public PublicKeyRequest()
        {
            RequestUrl = "https://fraud.mch.weixin.qq.com/risk/getpublickey";
        }
    }
}
