using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ContentPoiData Data Structure.
    /// </summary>
    [Serializable]
    public class ContentPoiData : AopObject
    {
        /// <summary>
        /// poi纬度
        /// </summary>
        [XmlElement("latitude")]
        public string Latitude { get; set; }

        /// <summary>
        /// poi经度
        /// </summary>
        [XmlElement("longitude")]
        public string Longitude { get; set; }

        /// <summary>
        /// 位置信息
        /// </summary>
        [XmlElement("poi_name")]
        public string PoiName { get; set; }
    }
}
