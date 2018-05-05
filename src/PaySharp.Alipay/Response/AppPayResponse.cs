using PaySharp.Alipay.Request;
using PaySharp.Core.Response;

namespace PaySharp.Alipay.Response
{
    public class AppPayResponse : IResponse
    {
        public AppPayResponse(AppPayRequest request)
        {
            OrderInfo = request.GatewayData.ToUrl();
        }

        /// <summary>
        /// 用于唤起App的订单参数
        /// </summary>
        public string OrderInfo { get; set; }

        public string Raw { get; set; }
    }
}
