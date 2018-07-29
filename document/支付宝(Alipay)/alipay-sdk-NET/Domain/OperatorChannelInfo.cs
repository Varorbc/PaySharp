using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// OperatorChannelInfo Data Structure.
    /// </summary>
    [Serializable]
    public class OperatorChannelInfo : AopObject
    {
        /// <summary>
        /// 渠道编码
        /// </summary>
        [XmlElement("item_code")]
        public string ItemCode { get; set; }

        /// <summary>
        /// 渠道描述
        /// </summary>
        [XmlElement("item_desc")]
        public string ItemDesc { get; set; }

        /// <summary>
        /// 渠道名称
        /// </summary>
        [XmlElement("item_name")]
        public string ItemName { get; set; }

        /// <summary>
        /// 渠道是否可用
        /// </summary>
        [XmlElement("item_status")]
        public string ItemStatus { get; set; }
    }
}
