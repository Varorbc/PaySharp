
namespace ICanPay.Core
{
    /// <summary>
    /// 网关的交易类型
    /// </summary>
    public enum GatewayTradeType
    {
        /// <summary>
        /// App支付
        /// </summary>
        App,

        /// <summary>
        /// 手机网站支付
        /// </summary>
        Wap,

        /// <summary>
        /// 电脑网站支付
        /// </summary>
        Web,

        /// <summary>
        /// 扫码支付
        /// </summary>
        Scan
    }
}