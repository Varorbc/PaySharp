
namespace ICanPay.Core
{
    /// <summary>
    /// 网关通知的支付结果类型
    /// </summary>
    public enum PayResultType
    {

        /// <summary>
        /// 无效网关
        /// </summary>
        None,

        /// <summary>
        /// 支付失败
        /// </summary>
        Failed,

        /// <summary>
        /// 支付成功
        /// </summary>
        Succeed

    }
}
