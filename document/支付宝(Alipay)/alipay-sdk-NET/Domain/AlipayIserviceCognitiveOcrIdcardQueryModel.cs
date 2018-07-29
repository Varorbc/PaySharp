using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayIserviceCognitiveOcrIdcardQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayIserviceCognitiveOcrIdcardQueryModel : AopObject
    {
        /// <summary>
        /// 身份证图片base64编码内容
        /// </summary>
        [XmlElement("image_content")]
        public string ImageContent { get; set; }
    }
}
