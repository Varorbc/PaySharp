using PaySharp.Unionpay.Domain;
using PaySharp.Unionpay.Response;

namespace PaySharp.Unionpay.Request
{
    public class BillDownloadRequest : BaseRequest<BillDownloadModel, BillDownloadResponse>
    {
        public BillDownloadRequest()
        {
            RequestUrl = "https://filedownload.95516.com/";
        }

        internal override void Execute(Merchant merchant)
        {
            GatewayData.Remove("backUrl");
            GatewayData.Remove("frontUrl");
        }
    }
}
