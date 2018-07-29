using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ParkingScene Data Structure.
    /// </summary>
    [Serializable]
    public class ParkingScene : AopObject
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        [XmlElement("car_number")]
        public string CarNumber { get; set; }

        /// <summary>
        /// 车辆入场的时间，格式"YYYY-MM-DD HH:mm:ss"，24小时制
        /// </summary>
        [XmlElement("in_time")]
        public string InTime { get; set; }

        /// <summary>
        /// 停车场ID
        /// </summary>
        [XmlElement("parking_id")]
        public string ParkingId { get; set; }

        /// <summary>
        /// 停车场名称
        /// </summary>
        [XmlElement("parking_name")]
        public string ParkingName { get; set; }
    }
}
