
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
        INotify BuildRefundQuery();

        /// <summary>
        /// 初始化退款查询订单参数
        /// </summary>
        void InitRefundQuery();
    }
}
