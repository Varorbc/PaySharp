
namespace ICanPay.Core
{
    /// <summary>
    /// 支付订单通过公众号提交
    /// </summary>
    public interface IPaymentPublic
    {
        /// <summary>
        /// 创建支付订单数据
        /// </summary>
        string BuildPaymentPublic();
    }
}
