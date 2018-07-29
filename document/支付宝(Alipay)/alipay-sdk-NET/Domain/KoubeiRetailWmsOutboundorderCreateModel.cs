using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiRetailWmsOutboundorderCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiRetailWmsOutboundorderCreateModel : AopObject
    {
        /// <summary>
        /// 操作人信息
        /// </summary>
        [XmlElement("operate_context")]
        public OperateContext OperateContext { get; set; }

        /// <summary>
        /// 出库通知单货品明细列表
        /// </summary>
        [XmlArray("order_lines")]
        [XmlArrayItem("outbound_order_line")]
        public List<OutboundOrderLine> OrderLines { get; set; }

        /// <summary>
        /// 出库通知单主体
        /// </summary>
        [XmlElement("outbound_order")]
        public OutboundOrder OutboundOrder { get; set; }
    }
}
