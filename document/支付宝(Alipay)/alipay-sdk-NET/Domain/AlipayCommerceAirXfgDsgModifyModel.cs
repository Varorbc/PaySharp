using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayCommerceAirXfgDsgModifyModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayCommerceAirXfgDsgModifyModel : AopObject
    {
        /// <summary>
        /// 用户年龄
        /// </summary>
        [XmlElement("age")]
        public string Age { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [XmlElement("nam")]
        public string Nam { get; set; }

        /// <summary>
        /// 男
        /// </summary>
        [XmlElement("sex")]
        public string Sex { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("xbw")]
        public string Xbw { get; set; }
    }
}
