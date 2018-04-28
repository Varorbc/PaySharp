using PaySharp.Core.Request;

namespace PaySharp.Alipay.Response
{
    public class CancelResponse : BaseResponse
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
        /// 是否需要重试
        /// </summary>
        public string RetryFlag { get; set; }

        /// <summary>
        /// 本次撤销触发的交易动作 
        /// close：关闭交易，无退款
        /// refund：产生了退款
        /// </summary>
        public string Action { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
