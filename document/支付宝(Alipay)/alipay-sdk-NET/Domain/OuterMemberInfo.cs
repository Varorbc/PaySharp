using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// OuterMemberInfo Data Structure.
    /// </summary>
    [Serializable]
    public class OuterMemberInfo : AopObject
    {
        /// <summary>
        /// 商户记录的用户信息
        /// </summary>
        [XmlElement("user_info")]
        public string UserInfo { get; set; }
    }
}
