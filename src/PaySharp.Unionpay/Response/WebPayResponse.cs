using PaySharp.Core.Response;
using PaySharp.Unionpay.Request;

namespace PaySharp.Unionpay.Response
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
