using PaySharp.Alipay.Domain;
using PaySharp.Alipay.Response;

namespace PaySharp.Alipay.Request
{
    public class TransferRequest : BaseRequest<TransferModel, TransferResponse>
    {
        public TransferRequest()
            : base("alipay.fund.trans.toaccount.transfer")
        {
        }
    }
}
