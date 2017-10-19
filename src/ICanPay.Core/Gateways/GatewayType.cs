
namespace ICanPay.Core
{
    /// <summary>
    /// 网关类型
    /// </summary>
    public enum GatewayType
    {
        /// <summary>
        /// 未知网关类型
        /// </summary>
        None = 0,


        /// <summary>
        /// 财付通
        /// </summary>
        Tenpay,


        /// <summary>
        /// 易宝
        /// </summary>
        Yeepay,


        /// <summary>
        /// 支付宝
        /// </summary>
        Alipay,


        /// <summary>
        /// 微信支付
        /// </summary>
        Wechatpay
    }
}