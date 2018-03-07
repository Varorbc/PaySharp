using ICanPay.Alipay.Response;
using ICanPay.Core;
using ICanPay.Core.Request;
using ICanPay.Core.Utils;

namespace ICanPay.Alipay.Request
{
    public class AppPayRequest : Request<AppPayResponse>
    {
        public AppPayRequest()
        {
            GatewayData.Add(Constant.METHOD, Constant.APP);
        }

        public override void AddGatewayData(object obj)
        {
            base.AddGatewayData(obj);

            GatewayData.Add(Constant.BIZ_CONTENT, Util.SerializeObject(obj));
        }
    }
}
