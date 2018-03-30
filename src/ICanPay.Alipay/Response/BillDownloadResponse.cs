using ICanPay.Core.Utils;

namespace ICanPay.Alipay.Response
{
    public class BillDownloadResponse : BaseResponse
    {
        /// <summary>
        /// 账单下载地址链接，获取连接后30秒后未下载，链接地址失效。
        /// </summary>
        public string BillDownloadUrl { get; set; }

        /// <summary>
        /// 账单文件
        /// </summary>
        public byte[] BillFile
        {
            get
            {
                if (_billFile == null)
                {
                    _billFile = HttpUtil.Download(BillDownloadUrl);
                }

                return _billFile;
            }
        }
        private byte[] _billFile;
    }
}
