using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ZolozAuthenticationCustomerAnonymousfacesearchMatchModel Data Structure.
    /// </summary>
    [Serializable]
    public class ZolozAuthenticationCustomerAnonymousfacesearchMatchModel : AopObject
    {
        /// <summary>
        /// 地域编码
        /// </summary>
        [XmlElement("areacode")]
        public string Areacode { get; set; }

        /// <summary>
        /// 活体照片的二进制内容，然后做base64编码
        /// </summary>
        [XmlElement("authimg")]
        public string Authimg { get; set; }

        /// <summary>
        /// 业务量规模
        /// </summary>
        [XmlElement("bizscale")]
        public string Bizscale { get; set; }

        /// <summary>
        /// 商户品牌
        /// </summary>
        [XmlElement("brandcode")]
        public string Brandcode { get; set; }

        /// <summary>
        /// 商户机具唯一编码，关键参数
        /// </summary>
        [XmlElement("devicenum")]
        public string Devicenum { get; set; }

        /// <summary>
        /// 群组
        /// </summary>
        [XmlElement("group")]
        public string Group { get; set; }

        /// <summary>
        /// 门店编码
        /// </summary>
        [XmlElement("storecode")]
        public string Storecode { get; set; }

        /// <summary>
        /// 有效期天数，如7天、30天、365天
        /// </summary>
        [XmlElement("validtimes")]
        public string Validtimes { get; set; }
    }
}
