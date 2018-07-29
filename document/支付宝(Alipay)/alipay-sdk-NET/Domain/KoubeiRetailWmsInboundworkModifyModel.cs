using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiRetailWmsInboundworkModifyModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiRetailWmsInboundworkModifyModel : AopObject
    {
        /// <summary>
        /// 扩展字段，json格式
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 入库作业id
        /// </summary>
        [XmlElement("inbound_work_id")]
        public string InboundWorkId { get; set; }

        /// <summary>
        /// 操作上下文
        /// </summary>
        [XmlElement("operate_context")]
        public OperateContext OperateContext { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 入库作业明细列表
        /// </summary>
        [XmlArray("work_details")]
        [XmlArrayItem("work_detail")]
        public List<WorkDetail> WorkDetails { get; set; }
    }
}
