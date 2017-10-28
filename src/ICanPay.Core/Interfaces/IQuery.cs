
namespace ICanPay.Core
{
    /// <summary>
    /// 查询订单接口
    /// </summary>
    public interface IQuery
    {
        /// <summary>
        /// 生成查询订单参数
        /// </summary>
        INotify BuildQuery();

        /// <summary>
        /// 初始化查询订单参数
        /// </summary>
        void InitQuery();
    }
}
