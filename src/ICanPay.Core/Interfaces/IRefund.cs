
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
        /// <param name="auxiliary">辅助参数</param>
        INotify BuildRefund(IAuxiliary auxiliary);

        /// <summary>
        /// 初始化退款订单参数
        /// </summary>
        /// <param name="auxiliary">辅助参数</param>
        void InitRefund(IAuxiliary auxiliary);
    }
}
