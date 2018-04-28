namespace PaySharp.Core
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
        /// 签名类型
        /// </summary>
        string SignType { get; }

        /// <summary>
        /// 网关回发通知URL
        /// </summary>
        string NotifyUrl { get; set; }
    }
}
