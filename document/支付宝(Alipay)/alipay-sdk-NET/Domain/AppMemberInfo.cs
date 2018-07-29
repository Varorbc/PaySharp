using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AppMemberInfo Data Structure.
    /// </summary>
    [Serializable]
    public class AppMemberInfo : AopObject
    {
        /// <summary>
        /// 邀请时间
        /// </summary>
        [XmlElement("gmt_invite")]
        public string GmtInvite { get; set; }

        /// <summary>
        /// 加入时间
        /// </summary>
        [XmlElement("gmt_join")]
        public string GmtJoin { get; set; }

        /// <summary>
        /// 支付宝登录账号
        /// </summary>
        [XmlElement("logon_id")]
        public string LogonId { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [XmlElement("nick_name")]
        public string NickName { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary>
        [XmlElement("portrait")]
        public string Portrait { get; set; }

        /// <summary>
        /// 角色类型
        /// </summary>
        [XmlElement("role")]
        public string Role { get; set; }

        /// <summary>
        /// 成员的状态，VALID-有效，UNCONFIRMED-未确认，TIMEOUT-已经失效，REFUSED-用户拒绝
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 支付宝用户id
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
