namespace PaySharp.Core
{
    /// <summary>
    /// 未知网关事件数据
    /// </summary>
    public class UnknownGatewayEventArgs : NotifyEventArgs
    {
        #region 构造函数

        /// <summary>
        /// 初始化未知网关事件数据
        /// </summary>
        /// <param name="gateway">支付网关</param>
        public UnknownGatewayEventArgs(BaseGateway gateway)
            : base(gateway)
        {
        }

        #endregion
    }
}
