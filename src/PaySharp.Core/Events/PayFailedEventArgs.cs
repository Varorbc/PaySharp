namespace PaySharp.Core
{
    /// <summary>
    /// 支付失败网关事件数据
    /// </summary>
    public class PayFailedEventArgs : PayEventArgs
    {
        #region 构造函数

        /// <summary>
        /// 初始化支付失败网关事件数据
        /// </summary>
        /// <param name="gateway">支付网关</param>
        public PayFailedEventArgs(BaseGateway gateway)
            : base(gateway)
        {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 支付失败信息
        /// </summary>
        public string Message { get; set; }

        #endregion
    }
}
