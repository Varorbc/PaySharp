using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// BillInferenceResult Data Structure.
    /// </summary>
    [Serializable]
    public class BillInferenceResult : AopObject
    {
        /// <summary>
        /// 角度
        /// </summary>
        [XmlElement("angle")]
        public long Angle { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        [XmlElement("bill_score")]
        public long BillScore { get; set; }

        /// <summary>
        /// 算法版本
        /// </summary>
        [XmlElement("bill_version")]
        public string BillVersion { get; set; }

        /// <summary>
        /// 发票金额
        /// </summary>
        [XmlArray("capital_sum")]
        [XmlArrayItem("string")]
        public List<string> CapitalSum { get; set; }

        /// <summary>
        /// 发票时间
        /// </summary>
        [XmlArray("date")]
        [XmlArrayItem("string")]
        public List<string> Date { get; set; }

        /// <summary>
        /// 发票报销人
        /// </summary>
        [XmlArray("name")]
        [XmlArrayItem("string")]
        public List<string> Name { get; set; }

        /// <summary>
        /// 发票号
        /// </summary>
        [XmlArray("no")]
        [XmlArrayItem("string")]
        public List<string> No { get; set; }

        /// <summary>
        /// 分辨率
        /// </summary>
        [XmlArray("rotate_shape")]
        [XmlArrayItem("string")]
        public List<string> RotateShape { get; set; }

        /// <summary>
        /// 发票标题
        /// </summary>
        [XmlArray("title")]
        [XmlArrayItem("string")]
        public List<string> Title { get; set; }
    }
}
