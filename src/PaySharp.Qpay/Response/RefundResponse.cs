using PaySharp.Core;
using PaySharp.Core.Request;

namespace PaySharp.Qpay.Response
{
    public class RefundResponse : BaseResponse
    {
        /// <summary>
        /// QQ钱包订单号
        /// </summary>
        [ReName(Name = "transaction_id")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 商户退款单号	
        /// </summary>
        public string OutRefundNo { get; set; }

        /// <summary>
        /// QQ钱包退款单号	
        /// </summary>
        [ReName(Name = "refund_id")]
        public string RefundNo { get; set; }

        /// <summary>
        /// 退款方式
        /// ORIGINAL 原路退回
        /// BALANCE 退款到余额
        /// </summary>
        public string RefundChannel { get; set; }

        /// <summary>
        /// 退款申请金额
        /// </summary>
        [ReName(Name = "refund_fee")]
        public int RefundAmount { get; set; }

        /// <summary>
        /// 订单金额
        /// 订单总金额，单位为分
        /// </summary>
        [ReName(Name = "total_fee")]
        public int TotalAmount { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
