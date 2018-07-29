using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// SceneDetail Data Structure.
    /// </summary>
    [Serializable]
    public class SceneDetail : AopObject
    {
        /// <summary>
        /// 场景描述
        /// </summary>
        [XmlElement("desc")]
        public string Desc { get; set; }

        /// <summary>
        /// 场景id
        /// </summary>
        [XmlElement("scene_id")]
        public string SceneId { get; set; }

        /// <summary>
        /// 场景配置的图片
        /// </summary>
        [XmlElement("scene_image")]
        public string SceneImage { get; set; }

        /// <summary>
        /// 小蚂答场景标题
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }
    }
}
