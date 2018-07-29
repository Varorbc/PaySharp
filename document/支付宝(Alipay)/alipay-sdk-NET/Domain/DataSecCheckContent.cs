using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// DataSecCheckContent Data Structure.
    /// </summary>
    [Serializable]
    public class DataSecCheckContent : AopObject
    {
        /// <summary>
        /// 文本或图片对应的请求唯一值，用于标识文本或图片内容
        /// </summary>
        [XmlElement("data_id")]
        public string DataId { get; set; }

        /// <summary>
        /// 数据来源类型:TEXT--文本，IMAGE--图片
        /// </summary>
        [XmlElement("scene_type")]
        public string SceneType { get; set; }

        /// <summary>
        /// 待校验的文本数据(如果包含富文本，请一起传入)
        /// </summary>
        [XmlElement("text")]
        public string Text { get; set; }

        /// <summary>
        /// 待校验图片对应地址
        /// </summary>
        [XmlArray("urls")]
        [XmlArrayItem("string")]
        public List<string> Urls { get; set; }
    }
}
