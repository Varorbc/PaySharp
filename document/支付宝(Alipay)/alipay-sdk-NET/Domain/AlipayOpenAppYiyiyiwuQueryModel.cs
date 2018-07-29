using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenAppYiyiyiwuQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenAppYiyiyiwuQueryModel : AopObject
    {
        /// <summary>
        /// 12
        /// </summary>
        [XmlElement("rucan")]
        public string Rucan { get; set; }
    }
}
