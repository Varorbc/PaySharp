using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// CertFields Data Structure.
    /// </summary>
    [Serializable]
    public class CertFields : AopObject
    {
        /// <summary>
        /// 地址
        /// </summary>
        [XmlElement("address")]
        public string Address { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [XmlElement("birth")]
        public string Birth { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        [XmlElement("certno")]
        public string Certno { get; set; }

        /// <summary>
        /// 有效期
        /// </summary>
        [XmlElement("expires")]
        public string Expires { get; set; }

        /// <summary>
        /// 有效期结束日期
        /// </summary>
        [XmlElement("expiresend")]
        public string Expiresend { get; set; }

        /// <summary>
        /// 有效期开始时间
        /// </summary>
        [XmlElement("expiresstart")]
        public string Expiresstart { get; set; }

        /// <summary>
        /// 签发机关
        /// </summary>
        [XmlElement("issuingauthority")]
        public string Issuingauthority { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [XmlElement("number")]
        public string Number { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        [XmlElement("race")]
        public string Race { get; set; }

        /// <summary>
        /// 换证次数
        /// </summary>
        [XmlElement("renewalnum")]
        public string Renewalnum { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [XmlElement("sex")]
        public string Sex { get; set; }
    }
}
