using PaySharp.Allinpay.Enum;
using PaySharp.Core;
using PaySharp.Core.Request;

namespace PaySharp.Allinpay.Response
{
    public class QueryResponse : BaseResponse
    {
        /// <summary>
        /// 交易账户
        /// </summary>
        [ReName(Name = "acct")]
        public string TradeAccount { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        [ReName(Name = "trxcode")]
        public TradeType? TradeType { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        [ReName(Name = "initamt")]
        public int TotalAmount { get; set; }

        /// <summary>
        /// 结算金额
        /// </summary>
        [ReName(Name = "trxamt")]
        public int SettleAmount { get; set; }

        /// <summary>
        /// 手续费金额
        /// </summary>
        [ReName(Name = "fee")]
        public int Poundage { get; set; }

        /// <summary>
        /// 渠道子商户号
        /// </summary>
        [ReName(Name = "cmid")]
        public string ChannelMchId { get; set; }

        /// <summary>
        /// 渠道号
        /// </summary>
        [ReName(Name = "chnlid")]
        public string ChannelId { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
