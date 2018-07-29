using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ArchiveFaceInfo Data Structure.
    /// </summary>
    [Serializable]
    public class ArchiveFaceInfo : AopObject
    {
        /// <summary>
        /// 人脸图片BASE64转换后字符串,大小限制为2M
        /// </summary>
        [XmlElement("face_image")]
        public string FaceImage { get; set; }

        /// <summary>
        /// 人脸图片类型,取值范围:  FACE 活体人脸图片  COMMERCIAL_PS_WITH_MASK 商业公安网带网纹人脸图片  RESIDENT 居民身份证图片  PS_RM_MASK_ENHANCED 公安网去网纹照片  HMT_PS 港澳台公安网
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }

        /// <summary>
        /// 图片可用性.true表示可用,false表示不可用
        /// </summary>
        [XmlElement("usable")]
        public bool Usable { get; set; }
    }
}
