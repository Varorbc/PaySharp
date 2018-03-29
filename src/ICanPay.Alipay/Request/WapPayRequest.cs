using ICanPay.Alipay.Response;
using ICanPay.Core;
using ICanPay.Core.Request;
using ICanPay.Core.Utils;

namespace ICanPay.Alipay.Request
{
    public class WapPayRequest : BaseRequest
    {
        public WapPayRequest()
            : base(Constant.WAP)
        {
        }
    }
}
