
namespace ICanPay.Core
{
    /// <summary>
    /// 表单支付
    /// </summary>
    public interface IFormPayment
    {
        /// <summary>
        /// 生成表单支付参数
        /// </summary>
        string BuildFormPayment();

        /// <summary>
        /// 初始化表单支付参数
        /// </summary>
        void InitFormPayment();
    }
}
