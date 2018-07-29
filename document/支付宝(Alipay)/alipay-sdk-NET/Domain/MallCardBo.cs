using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// MallCardBo Data Structure.
    /// </summary>
    [Serializable]
    public class MallCardBo : AopObject
    {
        /// <summary>
        /// 商圈会员卡权益描述
        /// </summary>
        [XmlArray("benefit_desc")]
        [XmlArrayItem("string")]
        public List<string> BenefitDesc { get; set; }

        /// <summary>
        /// 会员卡图片url
        /// </summary>
        [XmlElement("card_logo_url")]
        public string CardLogoUrl { get; set; }

        /// <summary>
        /// 扩展信息
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 等级展示名称
        /// </summary>
        [XmlElement("level_show_name")]
        public string LevelShowName { get; set; }

        /// <summary>
        /// 会员卡卡模版ID
        /// </summary>
        [XmlElement("template_id")]
        public string TemplateId { get; set; }

        /// <summary>
        /// 权益标题 多个权益用,分隔
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }
    }
}
