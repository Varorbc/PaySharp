using ICanPay.Alipay.Domain;
using ICanPay.Alipay.Response;

namespace ICanPay.Alipay.Request
{
    public class TransferRequest : BaseRequest<TransferModel, TransferResponse>
    {
        public TransferRequest()
            : base("alipay.fund.trans.toaccount.transfer")
        {
        }
    }
}
