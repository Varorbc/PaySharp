
namespace ICanPay.Core
{
    /// <summary>
    /// 撤销订单
    /// </summary>
    public interface ICancel
    {
        /// <summary>
        /// 生成撤销订单参数
        /// </summary>
        /// <param name="auxiliary">辅助参数</param>
        INotify BuildCancel(IAuxiliary auxiliary);

        /// <summary>
        /// 初始化撤销订单参数
        /// </summary>
        /// <param name="auxiliary">辅助参数</param>
        void InitCancel(IAuxiliary auxiliary);
    }
}
