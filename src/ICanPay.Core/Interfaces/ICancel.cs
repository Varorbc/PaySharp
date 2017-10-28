
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
        INotify BuildCancel();

        /// <summary>
        /// 初始化撤销订单参数
        /// </summary>
        void InitCancel();
    }
}
