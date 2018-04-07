using ICanPay.Core.Utils;
using System.Threading.Tasks;

namespace ICanPay.Wechatpay.Response
{
    public class BillDownloadResponse : BaseResponse
    {
        /// <summary>
        /// 获取账单文件
        /// </summary>
        public byte[] GetBillFile()
        {
            return _billFile;
        }

        /// <summary>
        /// 获取账单文件
        /// </summary>
        public async Task<byte[]> GetBillFileAsync()
        {
            return _billFile;
        }

        private byte[] _billFile;

        internal override void Execute(Merchant merchant)
        {
        }
    }
}
