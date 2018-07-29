using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AuthenticationInfo Data Structure.
    /// </summary>
    [Serializable]
    public class AuthenticationInfo : AopObject
    {
        /// <summary>
        /// 身份认证场景信息
        /// </summary>
        [XmlElement("authentication_scene")]
        public AuthenticationScene AuthenticationScene { get; set; }

        /// <summary>
        /// 标识一笔业务，业务方生成
        /// </summary>
        [XmlElement("biz_id")]
        public string BizId { get; set; }

        /// <summary>
        /// 业务扩展信息
        /// </summary>
        [XmlElement("extend_info")]
        public string ExtendInfo { get; set; }

        /// <summary>
        /// 身份认证业务用户主体信息
        /// </summary>
        [XmlElement("principal_info")]
        public PrincipalInfo PrincipalInfo { get; set; }
    }
}
