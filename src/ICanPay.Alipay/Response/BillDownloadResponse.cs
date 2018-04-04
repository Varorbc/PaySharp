using ICanPay.Core.Utils;
using System.Threading.Tasks;

namespace ICanPay.Alipay.Response
{
    public class BillDownloadResponse : BaseResponse
    {
        /// <summary>
        /// 账单下载地址链接，获取连接后30秒后未下载，链接地址失效。
        /// </summary>
        public string BillDownloadUrl { get; set; }

        /// <summary>
        /// 获取账单文件
        /// </summary>
        public byte[] GetBillFile()
        {
            if (_billFile == null && !string.IsNullOrEmpty(BillDownloadUrl))
            {
                _billFile = HttpUtil.Download(BillDownloadUrl);
            }

            return _billFile;
        }

        /// <summary>
        /// 获取账单文件
        /// </summary>
        public async Task<byte[]> GetBillFileAsync()
        {
            if (_billFile == null && !string.IsNullOrEmpty(BillDownloadUrl))
            {
                _billFile = await HttpUtil.DownloadAsync(BillDownloadUrl);
            }

            return _billFile;
        }

        private byte[] _billFile;
    }
}
