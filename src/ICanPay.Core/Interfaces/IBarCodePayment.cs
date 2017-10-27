namespace ICanPay.Core
{
    /// <summary>
    /// 条码支付
    /// </summary>
    public interface IBarcodePayment
    {
        /// <summary>
        /// 生成条码支付参数
        /// </summary>
        void BuildBarcodePayment();

        /// <summary>
        /// 初始化条码支付参数
        /// </summary>
        void InitBarcodePayment();
    }
}
