using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayCommerceIotModellistCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayCommerceIotModellistCreateModel : AopObject
    {
        /// <summary>
        /// 型号列表+不唯一+协议服务商用于在支付宝智能设备中心创建支持的设备型号+协议服务商指定
        /// </summary>
        [XmlArray("model_list")]
        [XmlArrayItem("iot_device_model")]
        public List<IotDeviceModel> ModelList { get; set; }

        /// <summary>
        /// 协议服务商id+唯一+指定操作数据归属于哪个协议服务商+协议服务商接入时由支付宝统一分配
        /// </summary>
        [XmlElement("protocol_supplier_id")]
        public string ProtocolSupplierId { get; set; }
    }
}
