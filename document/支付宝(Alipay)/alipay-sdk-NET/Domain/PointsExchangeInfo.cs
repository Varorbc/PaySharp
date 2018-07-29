using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// PointsExchangeInfo Data Structure.
    /// </summary>
    [Serializable]
    public class PointsExchangeInfo : AopObject
    {
        /// <summary>
        /// 兑换内容的ID
        /// </summary>
        [XmlArray("ids")]
        [XmlArrayItem("string")]
        public List<string> Ids { get; set; }

        /// <summary>
        /// 积分兑换内容的类型，比如券
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }
    }
}
