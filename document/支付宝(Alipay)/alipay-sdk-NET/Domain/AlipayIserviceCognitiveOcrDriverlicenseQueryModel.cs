using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayIserviceCognitiveOcrDriverlicenseQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayIserviceCognitiveOcrDriverlicenseQueryModel : AopObject
    {
        /// <summary>
        /// 驾驶证图片base64加密后内容，大小控制在1.5M以内
        /// </summary>
        [XmlElement("image_content")]
        public string ImageContent { get; set; }
    }
}
