using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// SceneMarketingContentGroup Data Structure.
    /// </summary>
    [Serializable]
    public class SceneMarketingContentGroup : AopObject
    {
        /// <summary>
        /// 营销内容列表
        /// </summary>
        [XmlArray("data_list")]
        [XmlArrayItem("scene_marketing_content")]
        public List<SceneMarketingContent> DataList { get; set; }

        /// <summary>
        /// 分组名称
        /// </summary>
        [XmlElement("group_name")]
        public string GroupName { get; set; }

        /// <summary>
        /// 简要描述
        /// </summary>
        [XmlElement("summary")]
        public string Summary { get; set; }
    }
}
