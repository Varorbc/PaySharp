namespace PaySharp.Core
{
    public class RefundSucceedEventArgs : NotifyEventArgs
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="gateway">支付网关</param>
        public RefundSucceedEventArgs(BaseGateway gateway)
            : base(gateway)
        {
        }

        #endregion
    }
}
