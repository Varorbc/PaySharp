
namespace ICanPay.Core
{
    /// <summary>
    /// 支付成功网关事件数据
    /// </summary>
    public class PaymentSucceedEventArgs : PaymentEventArgs
    {

        #region 构造函数

        /// <summary>
        /// 初始化支付成功网关事件数据
        /// </summary>
        /// <param name="gateway">支付网关</param>
        public PaymentSucceedEventArgs(GatewayBase gateway)
            : base(gateway)
        {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 通知数据
        /// </summary>
        public INotify Notify
        {
            get
            {
                return gateway.Notify;
            }
        }

        #endregion

    }
}
