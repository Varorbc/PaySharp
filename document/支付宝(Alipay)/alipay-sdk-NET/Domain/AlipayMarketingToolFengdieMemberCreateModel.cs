using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayMarketingToolFengdieMemberCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayMarketingToolFengdieMemberCreateModel : AopObject
    {
        /// <summary>
        /// 用户的昵称
        /// </summary>
        [XmlElement("nick")]
        public string Nick { get; set; }

        /// <summary>
        /// 空间管理员，可由 vip 账户代替，值为vip账号或该空间管理员的 origin_user_id
        /// </summary>
        [XmlElement("operator")]
        public string Operator { get; set; }

        /// <summary>
        /// 欲创建的空间成员所关联的第三方用户ID，由调用方保持其唯一性
        /// </summary>
        [XmlElement("origin_user_id")]
        public string OriginUserId { get; set; }

        /// <summary>
        /// 欲创建成员的空间ID
        /// </summary>
        [XmlElement("space_id")]
        public string SpaceId { get; set; }
    }
}
