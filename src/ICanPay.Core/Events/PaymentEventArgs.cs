using System;
using ICanPay.Core.Utils;

namespace ICanPay.Core
{
    /// <summary>
    /// 支付事件数据的基类
    /// </summary>
    public abstract class PaymentEventArgs : EventArgs
    {

        #region 私有字段

        protected GatewayBase gateway;
        private string notifyServerHostAddress;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化支付事件数据的基类
        /// </summary>
        /// <param name="gateway">支付网关</param>
        public PaymentEventArgs(GatewayBase gateway)
        {
            this.gateway = gateway;
            notifyServerHostAddress = HttpUtil.LocalIpAddress.ToString();
        }

        #endregion

        #region 属性

        /// <summary>
        /// 发送支付通知的网关IP地址
        /// </summary>
        public string NotifyServerHostAddress
        {
            get
            {
                return notifyServerHostAddress;
            }
        }

        /// <summary>
        /// 支付网关的数据
        /// </summary>
        public GatewayData GatewayData
        {
            get
            {
                return gateway.GatewayData;
            }
        }

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