using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayIserviceCognitiveOcrVehiclelicenseQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayIserviceCognitiveOcrVehiclelicenseQueryModel : AopObject
    {
        /// <summary>
        /// 行驶证图片base64加密后内容，大小限制在1.5M
        /// </summary>
        [XmlElement("image_content")]
        public string ImageContent { get; set; }
    }
}
