using PaySharp.Alipay.Domain;
using PaySharp.Alipay.Response;

namespace PaySharp.Alipay.Request
{
    public class BillDownloadRequest : BaseRequest<BillDownloadModel, BillDownloadResponse>
    {
        public BillDownloadRequest()
            : base("alipay.data.dataservice.bill.downloadurl.query")
        {
        }
    }
}
