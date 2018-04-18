using ICanPay.Core.Request;

namespace ICanPay.Wechatpay.Response
{
    internal class PublicKeyResponse : BaseResponse
    {
        /// <summary>
        /// RSA 公钥
        /// </summary>
        public static string PubKey { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
