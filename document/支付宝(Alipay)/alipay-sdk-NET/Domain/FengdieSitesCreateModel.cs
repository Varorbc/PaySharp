using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// FengdieSitesCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class FengdieSitesCreateModel : AopObject
    {
        /// <summary>
        /// 站点域名，默认为空间中第一个可用域名
        /// </summary>
        [XmlElement("domain")]
        public string Domain { get; set; }

        /// <summary>
        /// 站点名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 站点过期时间，默认为发布时间 + 3 个月（调用站点发布接口时候可以再次修改）
        /// </summary>
        [XmlElement("offline_time")]
        public string OfflineTime { get; set; }

        /// <summary>
        /// 站点页面在编辑器中默认展示的数据(废弃，请使用pages)
        /// </summary>
        [XmlElement("page")]
        public FengdieActivityCreatePageData Page { get; set; }

        /// <summary>
        /// 站点页面在编辑器中默认展示的数据
        /// </summary>
        [XmlArray("pages")]
        [XmlArrayItem("fengdie_activity_create_pages_data")]
        public List<FengdieActivityCreatePagesData> Pages { get; set; }

        /// <summary>
        /// 站点标题
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }
    }
}
