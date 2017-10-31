
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
        /// <param name="auxiliary">辅助参数</param>
        INotify BuildQuery(IAuxiliary auxiliary);

        /// <summary>
        /// 初始化查询订单参数
        /// </summary>
        /// <param name="auxiliary">辅助参数</param>
        void InitQuery(IAuxiliary auxiliary);
    }
}
