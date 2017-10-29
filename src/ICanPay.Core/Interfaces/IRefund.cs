
namespace ICanPay.Core
{
    /// <summary>
    /// 退款订单
    /// </summary>
    public interface IRefund
    {
        /// <summary>
        /// 生成退款订单参数
        /// </summary>
        INotify BuildRefund();

        /// <summary>
        /// 初始化退款订单参数
        /// </summary>
        void InitRefund();
    }
}
