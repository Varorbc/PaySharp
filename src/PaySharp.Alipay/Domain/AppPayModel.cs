namespace PaySharp.Alipay.Domain
{
    /// <summary>
    /// 手机支付模型
    /// </summary>
    public class AppPayModel : BasePayModel
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AppPayModel()
            :base("QUICK_MSECURITY_PAY")
        {
        }
    }
}
