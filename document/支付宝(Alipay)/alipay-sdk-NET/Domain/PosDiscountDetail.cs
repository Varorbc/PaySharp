using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// PosDiscountDetail Data Structure.
    /// </summary>
    [Serializable]
    public class PosDiscountDetail : AopObject
    {
        /// <summary>
        /// 优惠名称
        /// </summary>
        [XmlElement("discount_name")]
        public string DiscountName { get; set; }

        /// <summary>
        /// 优惠类型
        /// </summary>
        [XmlElement("discount_type")]
        public string DiscountType { get; set; }

        /// <summary>
        /// 扩展信息，存储优惠的详细模型。json对象格式，key和value都为字符串
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 商家出资优惠金额，以元为单位，精确到分
        /// </summary>
        [XmlElement("mrt_discount")]
        public string MrtDiscount { get; set; }

        /// <summary>
        /// 平台出资优惠金额，以元为单位，精确到分
        /// </summary>
        [XmlElement("rt_discount")]
        public string RtDiscount { get; set; }
    }
}
