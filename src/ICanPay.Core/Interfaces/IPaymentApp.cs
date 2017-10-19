
namespace ICanPay.Core
{
    /// <summary>
    /// 支付订单通过App提交
    /// </summary>
    public interface IPaymentApp
    {
        /// <summary>
        /// 创建支付订单数据
        /// </summary>
        string BuildPaymentApp();
    }
}
