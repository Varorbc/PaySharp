
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
        /// 验证
        /// </summary>
        /// <returns></returns>
        /// <param name="gatewayAuxiliaryType">辅助类型</param>
        bool Validate(GatewayAuxiliaryType gatewayAuxiliaryType);
    }
}
