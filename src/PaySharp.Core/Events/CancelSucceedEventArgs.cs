namespace PaySharp.Core
{
    public class CancelSucceedEventArgs : NotifyEventArgs
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="gateway">支付网关</param>
        public CancelSucceedEventArgs(BaseGateway gateway)
            : base(gateway)
        {
        }

        #endregion
    }
}
