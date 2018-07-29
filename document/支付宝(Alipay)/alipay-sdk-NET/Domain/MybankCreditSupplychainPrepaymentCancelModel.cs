using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// MybankCreditSupplychainPrepaymentCancelModel Data Structure.
    /// </summary>
    [Serializable]
    public class MybankCreditSupplychainPrepaymentCancelModel : AopObject
    {
        /// <summary>
        /// 买家身份信息
        /// </summary>
        [XmlElement("buyer")]
        public Member Buyer { get; set; }

        /// <summary>
        /// 预付申请单编号，由调用创建预付申请时自动分配。
        /// </summary>
        [XmlElement("prepay_apply_no")]
        public string PrepayApplyNo { get; set; }

        /// <summary>
        /// 接口幂等字段，相同requestId请求系统默认认为是相同的请求。此处requestId要求的格式为"{机构IpRoleId}_{机构生成的唯一请求ID}"。
        /// </summary>
        [XmlElement("request_id")]
        public string RequestId { get; set; }
    }
}
