
namespace ICanPay.Core
{
    /// <summary>
    /// 账单下载
    /// </summary>
    public interface IBillDownload
    {
        /// <summary>
        /// 生成账单下载订单参数
        /// </summary>
        INotify BuildBillDownload();

        /// <summary>
        /// 初始化账单下载订单参数
        /// </summary>
        void InitBillDownload();
    }
}
