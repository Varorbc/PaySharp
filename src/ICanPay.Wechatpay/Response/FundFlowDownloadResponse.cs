using ICanPay.Core.Request;
using System.Threading.Tasks;

namespace ICanPay.Wechatpay.Response
{
    public class FundFlowDownloadResponse : BaseResponse
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

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
