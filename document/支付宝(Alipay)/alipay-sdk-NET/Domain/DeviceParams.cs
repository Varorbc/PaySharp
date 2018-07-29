using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// DeviceParams Data Structure.
    /// </summary>
    [Serializable]
    public class DeviceParams : AopObject
    {
        /// <summary>
        /// 设备Id
        /// </summary>
        [XmlElement("device_id")]
        public string DeviceId { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        [XmlElement("device_name")]
        public string DeviceName { get; set; }

        /// <summary>
        /// 设备类型，目前有四种值：  VR一体机：VR_MACHINE、电视：TV、身份证：ID_CARD、工牌：WORK_CARD
        /// </summary>
        [XmlElement("device_type")]
        public string DeviceType { get; set; }
    }
}
