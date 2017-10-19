namespace ICanPay.Core
{
    /// <summary>
    /// 订单的金额、编号
    /// </summary>
    public interface OrderBase
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        string OutTradeNo { get; set; }

        /// <summary>
        /// 金额,单位元
        /// </summary>
        double Amount { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        string Body { get; set; }
    }
}
