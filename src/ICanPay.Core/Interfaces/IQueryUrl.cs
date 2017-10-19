
namespace ICanPay.Core
{
    /// <summary>
    /// 通过url地址来查询订单
    /// </summary>
    public interface IQueryUrl
    {
        /// <summary>
        /// 创建查询订单的url地址
        /// </summary>
        string BuildQueryUrl();
    }
}
