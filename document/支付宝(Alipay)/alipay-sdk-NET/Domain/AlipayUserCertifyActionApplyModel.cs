using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayUserCertifyActionApplyModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayUserCertifyActionApplyModel : AopObject
    {
        /// <summary>
        /// 表示申请认证信息的业务类型
        /// </summary>
        [XmlElement("biz_type")]
        public string BizType { get; set; }

        /// <summary>
        /// 商户和支付宝交互时，用于代表申请认证信息的商户ID
        /// </summary>
        [XmlElement("partner_id")]
        public string PartnerId { get; set; }
    }
}
