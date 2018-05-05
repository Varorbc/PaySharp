namespace PaySharp.Core
{
    public class UnKnownNotifyEventArgs : NotifyEventArgs
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="gateway">支付网关</param>
        public UnKnownNotifyEventArgs(BaseGateway gateway)
            : base(gateway)
        {
        }

        #endregion

        #region 属性

        public string Message { get; set; }

        #endregion
    }
}
