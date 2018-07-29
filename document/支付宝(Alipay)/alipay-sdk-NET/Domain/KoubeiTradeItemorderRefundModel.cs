using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiTradeItemorderRefundModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiTradeItemorderRefundModel : AopObject
    {
        /// <summary>
        /// 口碑订单号
        /// </summary>
        [XmlElement("order_no")]
        public string OrderNo { get; set; }

        /// <summary>
        /// 标识一次退款请求，同一笔订单多次退款需要保证唯一
        /// </summary>
        [XmlElement("out_request_no")]
        public string OutRequestNo { get; set; }

        /// <summary>
        /// 退款原因描述
        /// </summary>
        [XmlElement("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// 退货明细信息
        /// </summary>
        [XmlArray("refund_infos")]
        [XmlArrayItem("refund_info")]
        public List<RefundInfo> RefundInfos { get; set; }
    }
}
