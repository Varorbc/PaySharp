using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// CarModel Data Structure.
    /// </summary>
    [Serializable]
    public class CarModel : AopObject
    {
        /// <summary>
        /// 品牌名称
        /// </summary>
        [XmlElement("brand_name")]
        public string BrandName { get; set; }

        /// <summary>
        /// 配置类型
        /// </summary>
        [XmlElement("config_name")]
        public string ConfigName { get; set; }

        /// <summary>
        /// 排量
        /// </summary>
        [XmlElement("engine_desc")]
        public string EngineDesc { get; set; }

        /// <summary>
        /// 车系名称
        /// </summary>
        [XmlElement("family_short_name")]
        public string FamilyShortName { get; set; }

        /// <summary>
        /// 车辆驾驶类型
        /// </summary>
        [XmlElement("gear_box_type")]
        public string GearBoxType { get; set; }

        /// <summary>
        /// 新车购置价
        /// </summary>
        [XmlElement("purchase_price")]
        public string PurchasePrice { get; set; }

        /// <summary>
        /// 座位数
        /// </summary>
        [XmlElement("seat")]
        public string Seat { get; set; }

        /// <summary>
        /// 车辆类型编码
        /// </summary>
        [XmlElement("vehicle_class_code")]
        public string VehicleClassCode { get; set; }

        /// <summary>
        /// 车型代码
        /// </summary>
        [XmlElement("vehicle_code")]
        public string VehicleCode { get; set; }

        /// <summary>
        /// 车型名称
        /// </summary>
        [XmlElement("vehicle_name")]
        public string VehicleName { get; set; }

        /// <summary>
        /// 年份
        /// </summary>
        [XmlElement("year_pattern")]
        public string YearPattern { get; set; }
    }
}
