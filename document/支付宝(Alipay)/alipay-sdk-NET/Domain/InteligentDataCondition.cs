using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// InteligentDataCondition Data Structure.
    /// </summary>
    [Serializable]
    public class InteligentDataCondition : AopObject
    {
        /// <summary>
        /// 数据类型，支持枚举：文本：STRING；数值：NUMBER；长整型：LONG；浮点型：DOUBLE；日期：DATE；布尔：BOOLEAN；金额：MONEY
        /// </summary>
        [XmlElement("data_type")]
        public string DataType { get; set; }

        /// <summary>
        /// 数据限制类型，支持枚举：固定值：FIX；单选值：SELECT；区间值：RANGE;
        /// </summary>
        [XmlElement("limit_type")]
        public string LimitType { get; set; }

        /// <summary>
        /// 数据格式值；如：范围值:(1,10)，固定值:1
        /// </summary>
        [XmlElement("value")]
        public string Value { get; set; }
    }
}
