using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// DiscountByDayModel Data Structure.
    /// </summary>
    [Serializable]
    public class DiscountByDayModel : AopObject
    {
        /// <summary>
        /// 开始天数，最小为1
        /// </summary>
        [XmlElement("begin_day")]
        public long BeginDay { get; set; }

        /// <summary>
        /// 相对折扣，保留小数点2位
        /// </summary>
        [XmlElement("discount")]
        public string Discount { get; set; }

        /// <summary>
        /// 结束天数
        /// </summary>
        [XmlElement("end_day")]
        public long EndDay { get; set; }
    }
}
