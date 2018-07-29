using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// InsLiability Data Structure.
    /// </summary>
    [Serializable]
    public class InsLiability : AopObject
    {
        /// <summary>
        /// 保额
        /// </summary>
        [XmlElement("coverage")]
        public string Coverage { get; set; }

        /// <summary>
        /// 是否可以编辑,0-可选; 1-不可选,不支持; 2-必选,目前不打开
        /// </summary>
        [XmlElement("disabled")]
        public string Disabled { get; set; }

        /// <summary>
        /// 不计免赔 0，1，2
        /// </summary>
        [XmlElement("iop")]
        public string Iop { get; set; }

        /// <summary>
        /// 不计免赔保费
        /// </summary>
        [XmlElement("iop_premium")]
        public string IopPremium { get; set; }

        /// <summary>
        /// 责任描述
        /// </summary>
        [XmlElement("liability_desc")]
        public string LiabilityDesc { get; set; }

        /// <summary>
        /// 责任名称
        /// </summary>
        [XmlElement("liability_name")]
        public string LiabilityName { get; set; }

        /// <summary>
        /// 责任编码
        /// </summary>
        [XmlElement("liability_no")]
        public string LiabilityNo { get; set; }

        /// <summary>
        /// 责任保费
        /// </summary>
        [XmlElement("liability_premium")]
        public string LiabilityPremium { get; set; }

        /// <summary>
        /// options
        /// </summary>
        [XmlArray("options")]
        [XmlArrayItem("ins_option")]
        public List<InsOption> Options { get; set; }

        /// <summary>
        /// 责任保费
        /// </summary>
        [XmlElement("premium")]
        public string Premium { get; set; }

        /// <summary>
        /// 保额
        /// </summary>
        [XmlElement("sum_insured")]
        public InsSumInsured SumInsured { get; set; }
    }
}
