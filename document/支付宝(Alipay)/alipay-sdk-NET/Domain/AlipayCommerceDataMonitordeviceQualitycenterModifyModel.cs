using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayCommerceDataMonitordeviceQualitycenterModifyModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayCommerceDataMonitordeviceQualitycenterModifyModel : AopObject
    {
        /// <summary>
        /// device_id, 唯一标识设备，由openmonitor传递到质量中心。
        /// </summary>
        [XmlElement("asset_id")]
        public string AssetId { get; set; }

        /// <summary>
        /// fault_type，标识设备故障类型，由openmonitor传递到质量中心。
        /// </summary>
        [XmlElement("fault_type")]
        public string FaultType { get; set; }

        /// <summary>
        /// invoke_id, 用来回溯监控中心的调用方id，监控中心生成
        /// </summary>
        [XmlElement("invoke_id")]
        public long InvokeId { get; set; }

        /// <summary>
        /// quality_center_id，唯一，用于问题追踪去重，质量中心生成的唯一id。
        /// </summary>
        [XmlElement("quality_center_id")]
        public string QualityCenterId { get; set; }

        /// <summary>
        /// result, 机具处理结果，由质量中心生成。
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

        /// <summary>
        /// result_date, 处理结果的时间，质量中心生成。
        /// </summary>
        [XmlElement("result_date")]
        public string ResultDate { get; set; }

        /// <summary>
        /// result_msg，处理结果的描述，质量中心生成。
        /// </summary>
        [XmlElement("result_msg")]
        public string ResultMsg { get; set; }
    }
}
