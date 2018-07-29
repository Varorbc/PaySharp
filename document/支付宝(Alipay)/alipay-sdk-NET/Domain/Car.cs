using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// Car Data Structure.
    /// </summary>
    [Serializable]
    public class Car : AopObject
    {
        /// <summary>
        /// 发动机号
        /// </summary>
        [XmlElement("car_engine_no")]
        public string CarEngineNo { get; set; }

        /// <summary>
        /// 车架号
        /// </summary>
        [XmlElement("car_frame_no")]
        public string CarFrameNo { get; set; }

        /// <summary>
        /// 品牌型号
        /// </summary>
        [XmlElement("car_model_code")]
        public string CarModelCode { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        [XmlElement("car_no")]
        public string CarNo { get; set; }

        /// <summary>
        /// 该车辆数据来源，1 来自 ISV，2来自保险师内部数据
        /// </summary>
        [XmlElement("data_source")]
        public string DataSource { get; set; }

        /// <summary>
        /// 初次登记日期
        /// </summary>
        [XmlElement("first_register_date")]
        public string FirstRegisterDate { get; set; }

        /// <summary>
        /// 天津地区行驶证地址
        /// </summary>
        [XmlElement("license_address")]
        public string LicenseAddress { get; set; }

        /// <summary>
        /// 是否过户车
        /// </summary>
        [XmlElement("transfer_car")]
        public string TransferCar { get; set; }

        /// <summary>
        /// 过户日期
        /// </summary>
        [XmlElement("transfer_date")]
        public string TransferDate { get; set; }

        /// <summary>
        /// 所有需要报价机构对应的精友码
        /// </summary>
        [XmlArray("vehicle_info_list")]
        [XmlArrayItem("vehicle_info")]
        public List<VehicleInfo> VehicleInfoList { get; set; }

        /// <summary>
        /// 天津地区行驶证车辆类型
        /// </summary>
        [XmlElement("vehicle_type")]
        public string VehicleType { get; set; }
    }
}
