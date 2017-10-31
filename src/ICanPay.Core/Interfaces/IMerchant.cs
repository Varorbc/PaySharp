namespace ICanPay.Core
{
    /// <summary>
    /// 商户接口
    /// </summary>
    public interface IMerchant
    {

        /// <summary>
        /// 应用ID
        /// </summary>
        string AppId { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        string Sign { get; set; }

        /// <summary>
        /// 签名类型
        /// </summary>
        string SignType { get; }

        /// <summary>
        /// 网关回发通知URL
        /// </summary>
        string NotifyUrl { get; set; }

        ///// <summary>
        ///// 验证
        ///// </summary>
        ///// <param name="gatewayTradeType">网关交易类型</param>
        //void Validate(GatewayTradeType gatewayTradeType);
    }
}
