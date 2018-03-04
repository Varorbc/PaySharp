using ICanPay.Alipay.Request;
using ICanPay.Core.Response;

namespace ICanPay.Alipay.Response
{
    public class WebPayResponse : IResponse
    {
        public WebPayResponse(WebPayRequest request)
        {
            Html = request.GatewayData.ToForm(request.RequestUrl);
        }

        /// <summary>
        /// 生成的Html网页
        /// </summary>
        public string Html { get; set; }
    }
}
