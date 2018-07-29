using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayCommerceIotMsgcenterSendModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayCommerceIotMsgcenterSendModel : AopObject
    {
        /// <summary>
        /// 消息内容
        /// </summary>
        [XmlElement("content")]
        public string Content { get; set; }

        /// <summary>
        /// 消息发送的时间，毫秒级的时间戳
        /// </summary>
        [XmlElement("datetime")]
        public long Datetime { get; set; }

        /// <summary>
        /// 扩展参数，json序列化后的字符串
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 消息是否支持跳转链接
        /// </summary>
        [XmlElement("is_support_link")]
        public bool IsSupportLink { get; set; }

        /// <summary>
        /// 消息跳转链接
        /// </summary>
        [XmlElement("link")]
        public string Link { get; set; }

        /// <summary>
        /// 消息标题
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// 消息类型, 0：普通消息、1：发送push的消息
        /// </summary>
        [XmlElement("type")]
        public long Type { get; set; }

        /// <summary>
        /// 蚂蚁统一会员ID
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
