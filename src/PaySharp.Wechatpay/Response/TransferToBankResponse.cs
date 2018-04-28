using PaySharp.Core;
using PaySharp.Core.Request;

namespace PaySharp.Wechatpay.Response
{
    public class TransferToBankResponse : BaseResponse
    {
        /// <summary>
        /// 微信企业付款单号
        /// </summary>
        [ReName(Name = "payment_no")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [ReName(Name = "partner_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 代付金额
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 手续费金额
        /// </summary>
        [ReName(Name = "cmms_amt")]
        public int Poundage { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
