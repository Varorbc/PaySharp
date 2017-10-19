
namespace ICanPay.Core
{
    /// <summary>
    /// 订单是使用二维码支付时创建订单的支付二维码
    /// </summary>
    public interface IPaymentQRCode
    {
        /// <summary>
        /// 创建包含支付订单数据的二维码
        /// </summary>
        /// <returns></returns>
        string BuildPaymentQRCode();
    }
}