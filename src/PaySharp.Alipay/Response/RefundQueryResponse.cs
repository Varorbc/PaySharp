using PaySharp.Core.Request;
using Newtonsoft.Json;

namespace PaySharp.Alipay.Response
{
    public class RefundQueryResponse : BaseResponse
    {
        /// <summary>
        /// 支付宝交易号
        /// </summary>
        public string TradeNo { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 本笔退款对应的退款请求号
        /// </summary>
        [JsonProperty("out_request_no")]
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 发起退款时，传入的退款原因
        /// </summary>
        public string RefundReason { get; set; }

        /// <summary>
        /// 该笔退款所对应的交易的订单金额
        /// </summary>
        public double TotalAmount { get; set; }

        /// <summary>
        /// 退款金额
        /// </summary>
        public double RefundAmount { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
