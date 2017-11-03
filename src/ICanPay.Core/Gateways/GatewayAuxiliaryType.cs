
namespace ICanPay.Core
{
    /// <summary>
    /// 网关辅助类型
    /// </summary>
    public enum GatewayAuxiliaryType
    {
        /// <summary>
        /// 无操作
        /// </summary>
        NoAction,

        /// <summary>
        /// 查询
        /// </summary>
        Query,

        /// <summary>
        /// 关闭
        /// </summary>
        Close,

        /// <summary>
        /// 撤销
        /// </summary>
        Cancel,

        /// <summary>
        /// 退款
        /// </summary>
        Refund,

        /// <summary>
        /// 退款查询
        /// </summary>
        RefundQuery,

        /// <summary>
        /// 对账单下载
        /// </summary>
        BillDownload
    }
}
