using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// EcoApplySchedule Data Structure.
    /// </summary>
    [Serializable]
    public class EcoApplySchedule : AopObject
    {
        /// <summary>
        /// 批语
        /// </summary>
        [XmlElement("audit_comment")]
        public string AuditComment { get; set; }

        /// <summary>
        /// 审批时间(yyyy-MM-dd HH:mm:ss)
        /// </summary>
        [XmlElement("audit_time")]
        public string AuditTime { get; set; }

        /// <summary>
        /// 编辑标识：0-不可编辑，1-可编辑，2-需重新提交。
        /// </summary>
        [XmlElement("edit_flag")]
        public long EditFlag { get; set; }

        /// <summary>
        /// 申请单号
        /// </summary>
        [XmlElement("order_no")]
        public string OrderNo { get; set; }

        /// <summary>
        /// 审批顺序
        /// </summary>
        [XmlElement("order_num")]
        public long OrderNum { get; set; }

        /// <summary>
        /// 审批阶段状态编码如(1,2,3)
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 审批阶段状态描述(审核中，通过，拒绝)
        /// </summary>
        [XmlElement("status_desc")]
        public string StatusDesc { get; set; }

        /// <summary>
        /// 审批阶段编码
        /// </summary>
        [XmlElement("step")]
        public string Step { get; set; }

        /// <summary>
        /// 审批阶段描述如：初审，提交材料，市局审批，受理中心
        /// </summary>
        [XmlElement("step_desc")]
        public string StepDesc { get; set; }
    }
}
