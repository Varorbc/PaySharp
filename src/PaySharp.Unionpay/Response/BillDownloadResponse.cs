using PaySharp.Core;
using PaySharp.Core.Request;

namespace PaySharp.Unionpay.Response
{
    public class BillDownloadResponse : BaseResponse
    {
        /// <summary>
        /// 批量文件内容
        /// </summary>
        public string FileContent { get; set; }

        /// <summary>
        /// 文件名	
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 清算日期，格式MMDD
        /// </summary>
        [ReName(Name = "settleDate")]
        public string BillDate { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public string FileType { get; set; }

        /// <summary>
        /// 获取账单文件
        /// </summary>
        public byte[] GetBillFile()
        {
            return _billFile;
        }

        private byte[] _billFile;

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
            if (!string.IsNullOrEmpty(FileContent))
            {
                _billFile = CertUtil.Inflater(FileContent);
            }
        }
    }
}
