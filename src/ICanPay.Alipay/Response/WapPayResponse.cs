using ICanPay.Alipay.Request;
using ICanPay.Core.Response;

namespace ICanPay.Alipay.Response
{
    public class WapPayResponse : IResponse
    {
        public WapPayResponse(WapPayRequest request)
        {
            Url = $"{request.RequestUrl}&{request.GatewayData.ToUrl()}";
        }

        /// <summary>
        /// 跳转链接
        /// </summary>
        public string Url { get; set; }
    }
}
