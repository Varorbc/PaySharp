using ICanPay.Alipay.Response;
using ICanPay.Core;
using ICanPay.Core.Request;
using ICanPay.Core.Utils;

namespace ICanPay.Alipay.Request
{
    public class WebPayRequest : Request<WebPayResponse>
    {
        public WebPayRequest()
        {
            RequestUrl = "/gateway.do?charset=UTF-8";

            GatewayData.Add(Constant.METHOD, Constant.WEB);
        }

        public override void AddGatewayData(object obj)
        {
            base.AddGatewayData(obj);

            GatewayData.Add(Constant.BIZ_CONTENT, Util.SerializeObject(obj));
        }
    }
}
