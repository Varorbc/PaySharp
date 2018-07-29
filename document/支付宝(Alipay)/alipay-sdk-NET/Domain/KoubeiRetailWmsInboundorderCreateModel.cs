using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiRetailWmsInboundorderCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiRetailWmsInboundorderCreateModel : AopObject
    {
        /// <summary>
        /// 入库通知单主体
        /// </summary>
        [XmlElement("inbound_order")]
        public InboundOrder InboundOrder { get; set; }

        /// <summary>
        /// 操作人信息
        /// </summary>
        [XmlElement("operate_context")]
        public OperateContext OperateContext { get; set; }

        /// <summary>
        /// 入库通知单货品明细列表
        /// </summary>
        [XmlArray("order_lines")]
        [XmlArrayItem("inbound_order_line")]
        public List<InboundOrderLine> OrderLines { get; set; }
    }
}
