using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// LoanMoneyTypeAmt Data Structure.
    /// </summary>
    [Serializable]
    public class LoanMoneyTypeAmt : AopObject
    {
        /// <summary>
        /// 费用
        /// </summary>
        [XmlElement("fee")]
        public string Fee { get; set; }

        /// <summary>
        /// 正常利息金额
        /// </summary>
        [XmlElement("intr")]
        public string Intr { get; set; }

        /// <summary>
        /// 滞纳金
        /// </summary>
        [XmlElement("ovd_fine")]
        public string OvdFine { get; set; }

        /// <summary>
        /// 逾期利息金额
        /// </summary>
        [XmlElement("ovd_int")]
        public string OvdInt { get; set; }

        /// <summary>
        /// 逾期利息罚息
        /// </summary>
        [XmlElement("ovd_int_pny")]
        public string OvdIntPny { get; set; }

        /// <summary>
        /// 逾期本金金额
        /// </summary>
        [XmlElement("ovd_prin")]
        public string OvdPrin { get; set; }

        /// <summary>
        /// 逾期本金罚息
        /// </summary>
        [XmlElement("ovd_prin_pny")]
        public string OvdPrinPny { get; set; }

        /// <summary>
        /// 正常本金金额
        /// </summary>
        [XmlElement("prin")]
        public string Prin { get; set; }
    }
}
