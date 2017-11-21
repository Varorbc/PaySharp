
namespace ICanPay.Core
{
    /// <summary>
    /// 辅助接口
    /// </summary>
    public interface IAuxiliary
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        string OutTradeNo { get; set; }

        /// <summary>
        /// 支付系统订单号
        /// </summary>
        string TradeNo { get; set; }

        /// <summary>
        /// 商户退款单号
        /// </summary>
        string OutRefundNo { get; set; }

        /// <summary>
        /// 支付系统退款单号
        /// </summary>
        string RefundNo { get; set; }

        /// <summary>
        /// 退款金额
        /// </summary>
        double? RefundAmount { get; set; }

        /// <summary>
        /// 退款原因
        /// </summary>
        string RefundReason { get; set; }

        /// <summary>
        /// 账单日期
        /// </summary>
        string BillDate { get; set; }

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        /// <param name="gatewayAuxiliaryType">辅助类型</param>
        bool Validate(GatewayAuxiliaryType gatewayAuxiliaryType);
    }
}
