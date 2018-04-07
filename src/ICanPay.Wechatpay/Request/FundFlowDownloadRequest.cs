using ICanPay.Wechatpay.Domain;
using ICanPay.Wechatpay.Response;

namespace ICanPay.Wechatpay.Request
{
    public class FundFlowDownloadRequest : BaseRequest<FundFlowDownloadModel, FundFlowDownloadResponse>
    {
        public FundFlowDownloadRequest()
        {
            RequestUrl = "/pay/downloadfundflow";
        }
    }
}
