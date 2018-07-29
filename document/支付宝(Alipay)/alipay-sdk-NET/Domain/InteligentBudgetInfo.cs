using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// InteligentBudgetInfo Data Structure.
    /// </summary>
    [Serializable]
    public class InteligentBudgetInfo : AopObject
    {
        /// <summary>
        /// 预算数量
        /// </summary>
        [XmlElement("budget_total")]
        public string BudgetTotal { get; set; }

        /// <summary>
        /// 预算类型，枚举（QUANTITY：数量预算）
        /// </summary>
        [XmlElement("budget_type")]
        public string BudgetType { get; set; }
    }
}
