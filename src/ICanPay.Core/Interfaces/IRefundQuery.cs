
namespace ICanPay.Core
{
    /// <summary>
    /// 退款查询
    /// </summary>
    public interface IRefundQuery
    {
        /// <summary>
        /// 生成退款查询订单参数
        /// </summary>
        /// <param name="auxiliary">辅助参数</param>
        INotify BuildRefundQuery(IAuxiliary auxiliary);

        /// <summary>
        /// 初始化退款查询订单参数
        /// </summary>
        /// <param name="auxiliary">辅助参数</param>
        void InitRefundQuery(IAuxiliary auxiliary);
    }
}
