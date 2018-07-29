using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// IotDevice Data Structure.
    /// </summary>
    [Serializable]
    public class IotDevice : AopObject
    {
        /// <summary>
        /// 蓝牙MAC地址
        /// </summary>
        [XmlElement("bluetooth_mac")]
        public string BluetoothMac { get; set; }

        /// <summary>
        /// 设备控制面板地址
        /// </summary>
        [XmlElement("control_url")]
        public string ControlUrl { get; set; }

        /// <summary>
        /// 协议服务商用于唯一标识该设备的设备id(协议服务商定义)
        /// </summary>
        [XmlElement("device_id")]
        public string DeviceId { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        [XmlElement("device_name")]
        public string DeviceName { get; set; }

        /// <summary>
        /// 协议服务商用于唯一标识一个设备型号的型号id
        /// </summary>
        [XmlElement("model_id")]
        public string ModelId { get; set; }

        /// <summary>
        /// 设备序列号
        /// </summary>
        [XmlElement("sn")]
        public string Sn { get; set; }

        /// <summary>
        /// 设备WIFI的MAC地址
        /// </summary>
        [XmlElement("wifi_mac")]
        public string WifiMac { get; set; }
    }
}
