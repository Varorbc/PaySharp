using PaySharp.Core.Request;

namespace PaySharp.Allinpay.Response
{
    public class UnifiedPayResponse : BaseResponse
    {
        /// <summary>
        /// 支付信息
        /// </summary>
        /// <remarks>扫码支付则返回二维码串，js支付则返回json字符串
        /// QQ钱包及云闪付的JS支付返回支付的链接,商户只需跳转到此链接即可完成支付
        /// 支付宝App支付返回支付信息串</remarks>
        public string PayInfo { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
