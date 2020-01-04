using PaySharp.Core;

namespace PaySharp.Netpay.Domain
{
    public class SubOrders
    {
        /// <summary>
        /// 子商户号
        /// </summary>
        [ReName(Name = "mid")]
        public string MchId { get; set; }

        /// <summary>
        /// 商户子订单号
        /// </summary>
        [ReName(Name = "merOrderId")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 子商户分账金额
        /// </summary>
        public int TotalAmount { get; set; }
    }
}
