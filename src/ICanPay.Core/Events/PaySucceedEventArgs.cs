
namespace ICanPay.Core
{
    /// <summary>
    /// 支付成功网关事件数据
    /// </summary>
    public class PaySucceedEventArgs : PayEventArgs
    {

        #region 构造函数

        /// <summary>
        /// 初始化支付成功网关事件数据
        /// </summary>
        /// <param name="gateway">支付网关</param>
        public PaySucceedEventArgs(GatewayBase gateway)
            : base(gateway)
        {
        }

        #endregion
    }
}
