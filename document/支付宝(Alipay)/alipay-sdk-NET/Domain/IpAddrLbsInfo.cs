using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// IpAddrLbsInfo Data Structure.
    /// </summary>
    [Serializable]
    public class IpAddrLbsInfo : AopObject
    {
        /// <summary>
        /// IP地址归属地所以城市
        /// </summary>
        [XmlElement("city")]
        public string City { get; set; }

        /// <summary>
        /// IP归属地所在的省
        /// </summary>
        [XmlElement("province")]
        public string Province { get; set; }
    }
}
