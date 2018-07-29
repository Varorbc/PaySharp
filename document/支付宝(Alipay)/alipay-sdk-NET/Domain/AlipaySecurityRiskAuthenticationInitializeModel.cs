using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipaySecurityRiskAuthenticationInitializeModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipaySecurityRiskAuthenticationInitializeModel : AopObject
    {
        /// <summary>
        /// 用于身份安全业务初始化的公共入参
        /// </summary>
        [XmlElement("authentication_info")]
        public AuthenticationInfo AuthenticationInfo { get; set; }

        /// <summary>
        /// 用于身份安全业务初始化的业务入参
        /// </summary>
        [XmlElement("biz_info")]
        public string BizInfo { get; set; }

        /// <summary>
        /// 环境信息，包含设备信息、APP版本等
        /// </summary>
        [XmlElement("env_info")]
        public string EnvInfo { get; set; }
    }
}
