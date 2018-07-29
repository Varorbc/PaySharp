using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenAppMembersQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenAppMembersQueryModel : AopObject
    {
        /// <summary>
        /// 成员的角色类型，DEVELOPER-开发者，EXPERIENCER-体验者
        /// </summary>
        [XmlElement("role")]
        public string Role { get; set; }
    }
}
