using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// TravelMallRequest Data Structure.
    /// </summary>
    [Serializable]
    public class TravelMallRequest : AopObject
    {
        /// <summary>
        /// 目的地距目标综合体的距离(单位:米)
        /// </summary>
        [XmlElement("distance")]
        public long Distance { get; set; }

        /// <summary>
        /// 综合体ID
        /// </summary>
        [XmlElement("mall_id")]
        public string MallId { get; set; }
    }
}
