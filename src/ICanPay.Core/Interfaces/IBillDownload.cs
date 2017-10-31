using System.IO;

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
        /// <param name="type">账单类型</param>
        /// <param name="date">账单时间</param>
        Stream BuildBillDownload(string type, string date);

        /// <summary>
        /// 初始化账单下载订单参数
        /// </summary>
        /// <param name="type">账单类型</param>
        /// <param name="date">账单时间</param>
        void InitBillDownload(string type, string date);
    }
}
