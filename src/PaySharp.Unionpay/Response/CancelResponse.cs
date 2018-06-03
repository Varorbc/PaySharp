using PaySharp.Core;
using PaySharp.Core.Request;

namespace PaySharp.Unionpay.Response
{
    public class CancelResponse : BaseResponse
    {
        /// <summary>
        /// 查询流水号	
        /// </summary>
        public string QueryId { get; set; }

        /// <summary>
        /// 原交易查询流水号	
        /// </summary>
        public string OrigQryId { get; set; }

        /// <summary>
        /// 原交易商户订单号	
        /// </summary>
        public string OrigOrderId { get; set; }

        /// <summary>
        /// 交易金额
        /// </summary>
        [ReName(Name = "txnAmt")]
        public int TotalAmount { get; set; }

        /// <summary>
        /// 原交易商户发送交易时间		
        /// </summary>
        public string OrigTxnTime { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
