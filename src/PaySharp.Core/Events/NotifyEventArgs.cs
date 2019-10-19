using System;
using PaySharp.Core.Response;
using PaySharp.Core.Utils;

namespace PaySharp.Core
{
    /// <summary>
    /// 事件数据的基类
    /// </summary>
    public abstract class NotifyEventArgs : EventArgs
    {
        #region 私有字段

        protected BaseGateway _gateway;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="gateway">支付网关</param>
        protected NotifyEventArgs(BaseGateway gateway)
        {
            _gateway = gateway;
            NotifyServerHostAddress = HttpUtil.RemoteIpAddress;
        }

        #endregion

        #region 属性

        /// <summary>
        /// 发送支付通知的网关IP地址
        /// </summary>
        public string NotifyServerHostAddress { get; private set; }

        /// <summary>
        /// 网关的数据
        /// </summary>
        public GatewayData GatewayData => _gateway.GatewayData;

        /// <summary>
        /// 网关类型
        /// </summary>
        public Type GatewayType => _gateway.GetType();

        /// <summary>
        /// 通知数据
        /// </summary>
        public IResponse NotifyResponse => _gateway.NotifyResponse;

        /// <summary>
        /// 通知类型
        /// </summary>
        public NotifyType NotifyType => HttpUtil.RequestType == "GET" ? NotifyType.Sync : NotifyType.Async;

        #endregion
    }
}
