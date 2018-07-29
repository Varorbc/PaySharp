using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// OpusInfo Data Structure.
    /// </summary>
    [Serializable]
    public class OpusInfo : AopObject
    {
        /// <summary>
        /// 展示权重；必须大于等于0；排序规则：权重倒叙;默认值为0
        /// </summary>
        [XmlElement("display_weight")]
        public string DisplayWeight { get; set; }

        /// <summary>
        /// 外部作品id
        /// </summary>
        [XmlElement("external_opus_id")]
        public string ExternalOpusId { get; set; }

        /// <summary>
        /// 素材id
        /// </summary>
        [XmlElement("media_id")]
        public string MediaId { get; set; }

        /// <summary>
        /// 头图素材type；  枚举类型：PICTURE/VIDEO
        /// </summary>
        [XmlElement("media_type")]
        public string MediaType { get; set; }

        /// <summary>
        /// 素材url
        /// </summary>
        [XmlElement("media_url")]
        public string MediaUrl { get; set; }

        /// <summary>
        /// 作品id
        /// </summary>
        [XmlElement("opus_id")]
        public string OpusId { get; set; }

        /// <summary>
        /// 素材标题
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }
    }
}
