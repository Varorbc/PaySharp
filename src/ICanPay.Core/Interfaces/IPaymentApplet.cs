
namespace ICanPay.Core
{
    /// <summary>
    /// 支付订单通过小程序提交
    /// </summary>
    public interface IPaymentApplet
    {
        /// <summary>
        /// 创建支付订单数据
        /// </summary>
        string BuildPaymentApplet();
    }
}
