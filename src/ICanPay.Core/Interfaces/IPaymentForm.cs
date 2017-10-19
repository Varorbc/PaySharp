
namespace ICanPay.Core
{
    /// <summary>
    /// 支付订单通过form表单提交的HTML代码
    /// </summary>
    public interface IPaymentForm
    {
        /// <summary>
        /// 创建包含支付订单数据的form表单的HTML代码
        /// </summary>
        string BuildPaymentForm();
    }
}
