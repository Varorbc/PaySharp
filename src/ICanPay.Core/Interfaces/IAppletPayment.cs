
namespace ICanPay.Core
{
    /// <summary>
    /// 小程序支付
    /// </summary>
    public interface IAppletPayment
    {
        /// <summary>
        /// 生成小程序支付参数
        /// </summary>
        string BuildAppletPayment();

        /// <summary>
        /// 初始化小程序支付参数
        /// </summary>
        void InitAppletPayment();
    }
}
