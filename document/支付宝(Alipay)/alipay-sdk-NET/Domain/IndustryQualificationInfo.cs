using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// IndustryQualificationInfo Data Structure.
    /// </summary>
    [Serializable]
    public class IndustryQualificationInfo : AopObject
    {
        /// <summary>
        /// 商户行业资质图片。其值为使用ant.merchant.expand.indirect.image.upload上传图片得到的一串oss key
        /// </summary>
        [XmlElement("industry_qualification_image")]
        public string IndustryQualificationImage { get; set; }

        /// <summary>
        /// 商户行业资质类型，具体选值参见https://mif-pub.alipayobjects.com/QualificationType.xlsx
        /// </summary>
        [XmlElement("industry_qualification_type")]
        public string IndustryQualificationType { get; set; }
    }
}
