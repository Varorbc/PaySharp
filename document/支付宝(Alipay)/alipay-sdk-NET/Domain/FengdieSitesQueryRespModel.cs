using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// FengdieSitesQueryRespModel Data Structure.
    /// </summary>
    [Serializable]
    public class FengdieSitesQueryRespModel : AopObject
    {
        /// <summary>
        /// 云凤蝶模板的最近修改日期
        /// </summary>
        [XmlElement("gmt_modified")]
        public string GmtModified { get; set; }

        /// <summary>
        /// 云凤蝶模板ID
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }

        /// <summary>
        /// 云凤蝶模板是否上线的状态
        /// </summary>
        [XmlElement("is_online")]
        public bool IsOnline { get; set; }

        /// <summary>
        /// 云凤蝶模板的下线日期
        /// </summary>
        [XmlElement("offline_time")]
        public string OfflineTime { get; set; }

        /// <summary>
        /// 云凤蝶模板的负责人
        /// </summary>
        [XmlElement("owner")]
        public FengdieSitesOwner Owner { get; set; }

        /// <summary>
        /// 云凤蝶模板中所包含的页面
        /// </summary>
        [XmlArray("pages")]
        [XmlArrayItem("fengdie_sites_page_model")]
        public List<FengdieSitesPageModel> Pages { get; set; }

        /// <summary>
        /// 云凤蝶模板的当前状态
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 云凤蝶模板的名称
        /// </summary>
        [XmlElement("template_name")]
        public string TemplateName { get; set; }

        /// <summary>
        /// 云凤蝶模板的版本号
        /// </summary>
        [XmlElement("template_version")]
        public string TemplateVersion { get; set; }

        /// <summary>
        /// 云凤蝶模板的标题
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }
    }
}
