
namespace ICanPay.Core
{
    /// <summary>
    /// 网关通知的支付结果类型
    /// </summary>
    public enum PaymentResultType
    {

        /// <summary>
        /// 无效网关
        /// </summary>
        None = 0,


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
