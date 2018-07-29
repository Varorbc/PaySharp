using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiRetailWmsInboundorderBatchqueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiRetailWmsInboundorderBatchqueryModel : AopObject
    {
        /// <summary>
        /// 入库通知单id列表（外部业务单号列表二选一，不能同时传两个列表）
        /// </summary>
        [XmlArray("inbound_order_id_list")]
        [XmlArrayItem("string")]
        public List<string> InboundOrderIdList { get; set; }

        /// <summary>
        /// 操作人信息
        /// </summary>
        [XmlElement("operate_context")]
        public OperateContext OperateContext { get; set; }

        /// <summary>
        /// 外部业务单号列表（入库通知单id列表二选一，不能同时传两个列表）
        /// </summary>
        [XmlArray("out_biz_no_list")]
        [XmlArrayItem("string")]
        public List<string> OutBizNoList { get; set; }
    }
}
