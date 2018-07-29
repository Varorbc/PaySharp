using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiRetailWmsOutboundworkModifyModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiRetailWmsOutboundworkModifyModel : AopObject
    {
        /// <summary>
        /// 扩展字段，json格式
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 操作上下文
        /// </summary>
        [XmlElement("operate_context")]
        public OperateContext OperateContext { get; set; }

        /// <summary>
        /// 出库作业id
        /// </summary>
        [XmlElement("outbound_work_id")]
        public string OutboundWorkId { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 出库作业明细列表
        /// </summary>
        [XmlArray("work_details")]
        [XmlArrayItem("work_detail")]
        public List<WorkDetail> WorkDetails { get; set; }
    }
}
