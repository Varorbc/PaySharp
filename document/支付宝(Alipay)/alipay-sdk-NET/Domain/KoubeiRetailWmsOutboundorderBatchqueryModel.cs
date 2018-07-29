using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiRetailWmsOutboundorderBatchqueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiRetailWmsOutboundorderBatchqueryModel : AopObject
    {
        /// <summary>
        /// 操作人信息
        /// </summary>
        [XmlElement("operate_context")]
        public OperateContext OperateContext { get; set; }

        /// <summary>
        /// 外部业务单号（出库通知单id列表列表二选一）
        /// </summary>
        [XmlArray("out_biz_no_list")]
        [XmlArrayItem("string")]
        public List<string> OutBizNoList { get; set; }

        /// <summary>
        /// 出库通知单id列表（与外部业务单号列表二选一）
        /// </summary>
        [XmlArray("outbound_order_id_list")]
        [XmlArrayItem("string")]
        public List<string> OutboundOrderIdList { get; set; }
    }
}
