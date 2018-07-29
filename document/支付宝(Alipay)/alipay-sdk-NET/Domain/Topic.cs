using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// Topic Data Structure.
    /// </summary>
    [Serializable]
    public class Topic : AopObject
    {
        /// <summary>
        /// 营销位图片url
        /// </summary>
        [XmlElement("img_url")]
        public string ImgUrl { get; set; }

        /// <summary>
        /// 营销位跳转地址，点击营销位头图跳到的链接url。
        /// </summary>
        [XmlElement("link_url")]
        public string LinkUrl { get; set; }

        /// <summary>
        /// 营销位描述
        /// </summary>
        [XmlElement("sub_title")]
        public string SubTitle { get; set; }

        /// <summary>
        /// 营销位名称
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// 营销位id
        /// </summary>
        [XmlElement("topic_id")]
        public string TopicId { get; set; }

        /// <summary>
        /// 营销位内容列表
        /// </summary>
        [XmlArray("topic_items")]
        [XmlArrayItem("topic_item")]
        public List<TopicItem> TopicItems { get; set; }
    }
}
