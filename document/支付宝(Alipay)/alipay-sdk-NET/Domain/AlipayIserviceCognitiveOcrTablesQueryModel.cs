using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayIserviceCognitiveOcrTablesQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayIserviceCognitiveOcrTablesQueryModel : AopObject
    {
        /// <summary>
        /// 图片base64后内容，大小控制在1M以内
        /// </summary>
        [XmlElement("image_content")]
        public string ImageContent { get; set; }
    }
}
