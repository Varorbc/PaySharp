using ICanPay.Wechatpay.Domain;
using ICanPay.Wechatpay.Response;

namespace ICanPay.Wechatpay.Request
{
    public class BillDownloadRequest : BaseRequest<BillDownloadModel, BillDownloadResponse>
    {
        public BillDownloadRequest()
        {
            RequestUrl = "/pay/downloadbill";
        }

        internal override void Execute()
        {
            GatewayData.Remove("notify_url");
        }
    }
}
