
namespace ICanPay.Core
{
    /// <summary>
    /// 公众号支付
    /// </summary>
    public interface IPublicPayment
    {
        /// <summary>
        /// 生成公众号支付参数
        /// </summary>
        string BuildPublicPayment();

        /// <summary>
        /// 初始化公众号支付参数
        /// </summary>
        void InitPublicPayment();
    }
}
