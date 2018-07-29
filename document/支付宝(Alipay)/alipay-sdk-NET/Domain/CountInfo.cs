using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// CountInfo Data Structure.
    /// </summary>
    [Serializable]
    public class CountInfo : AopObject
    {
        /// <summary>
        /// 飞猪内容id
        /// </summary>
        [XmlElement("content_id")]
        public string ContentId { get; set; }

        /// <summary>
        /// 点赞数
        /// </summary>
        [XmlElement("support_count")]
        public long SupportCount { get; set; }

        /// <summary>
        /// 阅读数
        /// </summary>
        [XmlElement("total_page_view_count")]
        public long TotalPageViewCount { get; set; }
    }
}
