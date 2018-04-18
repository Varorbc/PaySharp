using ICanPay.Alipay.Domain;
using ICanPay.Alipay.Response;

namespace ICanPay.Alipay.Request
{
    public class WapPayRequest : BaseRequest<WapPayModel, WapPayResponse>
    {
        public WapPayRequest()
            : base("alipay.trade.wap.pay")
        {
        }
    }
}
