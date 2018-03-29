
namespace ICanPay.Core
{
    /// <summary>
    /// 未知网关事件数据
    /// </summary>
    public class UnknownGatewayEventArgs : PayEventArgs
    {

        #region 构造函数

        /// <summary>
        /// 初始化未知网关事件数据
        /// </summary>
        /// <param name="gateway">支付网关</param>
        public UnknownGatewayEventArgs(GatewayBase gateway)
            : base(gateway)
        {
        }

        #endregion

    }
}
