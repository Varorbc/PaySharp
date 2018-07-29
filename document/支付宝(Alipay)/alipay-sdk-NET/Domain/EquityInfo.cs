using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// EquityInfo Data Structure.
    /// </summary>
    [Serializable]
    public class EquityInfo : AopObject
    {
        /// <summary>
        /// ‘杰克琼斯’
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// ext_info
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// logo
        /// </summary>
        [XmlElement("logo")]
        public string Logo { get; set; }

        /// <summary>
        /// 天猫优惠券
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// APPLIED：已申领；UNAPPLIED：未申领；DELETED：已过期
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// url
        /// </summary>
        [XmlElement("url")]
        public string Url { get; set; }

        /// <summary>
        /// 优惠价值
        /// </summary>
        [XmlElement("value")]
        public string Value { get; set; }
    }
}
