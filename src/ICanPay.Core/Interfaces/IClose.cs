
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
        /// <param name="auxiliary">辅助参数</param>
        INotify BuildClose(IAuxiliary auxiliary);

        /// <summary>
        /// 初始化关闭订单参数
        /// </summary>
        /// <param name="auxiliary">辅助参数</param>
        void InitClose(IAuxiliary auxiliary);
    }
}
