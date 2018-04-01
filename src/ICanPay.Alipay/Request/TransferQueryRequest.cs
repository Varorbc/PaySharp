using ICanPay.Alipay.Domain;
using ICanPay.Alipay.Response;

namespace ICanPay.Alipay.Request
{
    public class TransferQueryRequest : BaseRequest<TransferQueryModel, TransferQueryResponse>
    {
        public TransferQueryRequest()
            : base("alipay.fund.trans.order.query")
        {
        }
    }
}
