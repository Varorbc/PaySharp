
namespace ICanPay.Core
{
    /// <summary>
    /// 支付失败网关事件数据
    /// </summary>
    public class PaymentFailedEventArgs : PaymentEventArgs
    {

        #region 构造函数

        /// <summary>
        /// 初始化支付失败网关事件数据
        /// </summary>
        /// <param name="gateway">支付网关</param>
        public PaymentFailedEventArgs(GatewayBase gateway)
            : base(gateway)
        {
        }

        #endregion


        #region 属性

        /// <summary>
        /// 支付网关类型
        /// </summary>
        public GatewayType GatewayType
        {
            get
            {
                return gateway.GatewayType;
            }
        }

        #endregion

    }
}
