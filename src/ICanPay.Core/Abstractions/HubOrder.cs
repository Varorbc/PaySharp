using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICanPay.Abstractions
{
    /// <summary>
    /// 通用的处理数据
    /// </summary>
    public class HubOrder
    {
        /// <summary>
        /// 支付机构订单Id
        /// </summary>
        public string GatewayOrderId { get; set; }

        /// <summary>
        /// 业务逻辑的订单Id
        /// </summary>
        public string BusinessOrderId { get; set; }

        /// <summary>
        /// 支付机构此次处理的时间
        /// </summary>
        public DateTimeOffset ProcessTime { get; set; }

        /// <summary>
        /// 支付处理器给的类型
        /// </summary>
        /// <remarks>可以利用此值决定 <see cref="RawData"/>的类型</remarks>
        public string GatewayType { get; set; }

        /// <summary>
        /// 原本的数据
        /// </summary>
        public object RawData { get; set; }

        /// <summary>
        /// 状态， 当为 null 时，为未知
        /// </summary>
        public HubHandlerDataStatus? Status { get; set; }
    }

    /// <summary>
    /// 支付数据状态
    /// </summary>
    public enum HubHandlerDataStatus
    {
        /// <summary>
        /// 支付成功
        /// </summary>
        Success,

        /// <summary>
        /// 支付失败
        /// </summary>
        Fail
    }
}
