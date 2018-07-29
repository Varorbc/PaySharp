using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipaySecurityRiskAuthenticationQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipaySecurityRiskAuthenticationQueryModel : AopObject
    {
        /// <summary>
        /// 身份安全业务场景信息
        /// </summary>
        [XmlElement("authentication_scene")]
        public AuthenticationScene AuthenticationScene { get; set; }

        /// <summary>
        /// 业务ID
        /// </summary>
        [XmlElement("biz_id")]
        public string BizId { get; set; }

        /// <summary>
        /// 业务信息
        /// </summary>
        [XmlElement("biz_info")]
        public string BizInfo { get; set; }

        /// <summary>
        /// 身份安全业务初始化后生成的token
        /// </summary>
        [XmlElement("token_id")]
        public string TokenId { get; set; }
    }
}
