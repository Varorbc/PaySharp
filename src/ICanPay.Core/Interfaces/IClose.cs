
namespace ICanPay.Core
{
    /// <summary>
    /// 关闭订单
    /// </summary>
    public interface IClose
    {
        /// <summary>
        /// 生成关闭订单参数
        /// </summary>
        INotify BuildClose();

        /// <summary>
        /// 初始化关闭订单参数
        /// </summary>
        void InitClose();
    }
}
