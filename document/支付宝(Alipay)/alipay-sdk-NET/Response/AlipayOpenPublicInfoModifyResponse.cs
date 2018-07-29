using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayOpenPublicInfoModifyResponse.
    /// </summary>
    public class AlipayOpenPublicInfoModifyResponse : AopResponse
    {
        /// <summary>
        /// 服务窗审核状态描述
        /// </summary>
        [XmlElement("audit_desc")]
        public string AuditDesc { get; set; }

        /// <summary>
        /// 服务窗审核状态，申请成功后返回AUDITING，等待风控审核
        /// </summary>
        [XmlElement("audit_status")]
        public string AuditStatus { get; set; }
    }
}
