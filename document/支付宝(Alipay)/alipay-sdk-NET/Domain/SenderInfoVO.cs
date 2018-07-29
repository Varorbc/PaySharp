using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// SenderInfoVO Data Structure.
    /// </summary>
    [Serializable]
    public class SenderInfoVO : AopObject
    {
        /// <summary>
        /// 区域
        /// </summary>
        [XmlElement("area")]
        public string Area { get; set; }

        /// <summary>
        /// 城市编码
        /// </summary>
        [XmlElement("city")]
        public string City { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [XmlElement("detail_address")]
        public string DetailAddress { get; set; }

        /// <summary>
        /// 发货人电话
        /// </summary>
        [XmlElement("mobile")]
        public string Mobile { get; set; }

        /// <summary>
        /// 发货人
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 省份编码
        /// </summary>
        [XmlElement("province")]
        public string Province { get; set; }
    }
}
