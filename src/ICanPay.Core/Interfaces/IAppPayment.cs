
namespace ICanPay.Core
{
    /// <summary>
    /// App支付
    /// </summary>
    public interface IAppPayment
    {
        /// <summary>
        /// 生成App支付参数
        /// </summary>
        string BuildAppPayment();

        /// <summary>
        /// 初始化App支付参数
        /// </summary>
        void InitAppPayment();
    }
}
