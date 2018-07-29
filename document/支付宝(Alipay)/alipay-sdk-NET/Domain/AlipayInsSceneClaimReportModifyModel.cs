using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayInsSceneClaimReportModifyModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayInsSceneClaimReportModifyModel : AopObject
    {
        /// <summary>
        /// 出险地点
        /// </summary>
        [XmlElement("accident_address")]
        public string AccidentAddress { get; set; }

        /// <summary>
        /// 出险描述
        /// </summary>
        [XmlElement("accident_desc")]
        public string AccidentDesc { get; set; }

        /// <summary>
        /// 出险时间
        /// </summary>
        [XmlElement("accident_time")]
        public string AccidentTime { get; set; }

        /// <summary>
        /// 理赔报案的属性字段，标准JSON格式
        /// </summary>
        [XmlElement("biz_data")]
        public string BizData { get; set; }

        /// <summary>
        /// 申请理赔的报案号
        /// </summary>
        [XmlElement("claim_report_no")]
        public string ClaimReportNo { get; set; }
    }
}
