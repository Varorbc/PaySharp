
namespace ICanPay.Core
{
    /// <summary>
    /// 通过form表单提交查询订单
    /// </summary>
    public interface IQueryForm
    {
        /// <summary>
        /// 创建包含查询订单数据的form表单的HTML代码
        /// </summary>
        string BuildQueryForm();
    }
}
