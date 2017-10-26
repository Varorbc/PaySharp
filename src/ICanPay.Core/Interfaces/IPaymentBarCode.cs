namespace ICanPay.Core
{
    /// <summary>
    /// 支付订单通过条码提交
    /// </summary>
    public interface IPaymentBarcode
    {
        /// <summary>
        /// 创建支付订单数据
        /// </summary>
        void BuildPaymentBarcode();
    }
}
