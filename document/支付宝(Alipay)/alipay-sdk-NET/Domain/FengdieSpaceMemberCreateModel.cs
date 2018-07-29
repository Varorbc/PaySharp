using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// FengdieSpaceMemberCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class FengdieSpaceMemberCreateModel : AopObject
    {
        /// <summary>
        /// 用户的昵称
        /// </summary>
        [XmlElement("nick")]
        public string Nick { get; set; }

        /// <summary>
        /// 云凤蝶业务空间成员所关联的第三方用户 ID
        /// </summary>
        [XmlElement("origin_user_id")]
        public string OriginUserId { get; set; }
    }
}
