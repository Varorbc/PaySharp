
namespace ICanPay.Core
{
    /// <summary>
    /// 撤销/关闭订单
    /// </summary>
    public interface ICancel
    {
        /// <summary>
        /// 生成撤销/关闭订单参数
        /// </summary>
        INotify BuildCancel();

        /// <summary>
        /// 初始化撤销/关闭订单参数
        /// </summary>
        void InitCancel();
    }
}
