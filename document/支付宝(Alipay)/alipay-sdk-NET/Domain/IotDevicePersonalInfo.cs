using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// IotDevicePersonalInfo Data Structure.
    /// </summary>
    [Serializable]
    public class IotDevicePersonalInfo : AopObject
    {
        /// <summary>
        /// 协议服务商用于唯一标识该设备的设备id(协议服务商定义)
        /// </summary>
        [XmlElement("device_id")]
        public string DeviceId { get; set; }

        /// <summary>
        /// 设备备注
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }
    }
}
