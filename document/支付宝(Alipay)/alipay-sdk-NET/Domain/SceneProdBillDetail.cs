using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// SceneProdBillDetail Data Structure.
    /// </summary>
    [Serializable]
    public class SceneProdBillDetail : AopObject
    {
        /// <summary>
        /// 账单类型，包括：正常，手续费，保证金 等类型，根据机构需求可以进行扩展。非必填，不填默认为正常。
        /// </summary>
        [XmlElement("bill_type")]
        public string BillType { get; set; }

        /// <summary>
        /// 到期日，时间格式为yyyy-MM-dd
        /// </summary>
        [XmlElement("due_date")]
        public string DueDate { get; set; }

        /// <summary>
        /// 应还利息，单位分
        /// </summary>
        [XmlElement("int_amt")]
        public string IntAmt { get; set; }

        /// <summary>
        /// 逾期天数，只能为数字，无逾期传0
        /// </summary>
        [XmlElement("overdue_days")]
        public string OverdueDays { get; set; }

        /// <summary>
        /// 应还罚息
        /// </summary>
        [XmlElement("pen_amt")]
        public string PenAmt { get; set; }

        /// <summary>
        /// 应还本金，单位分
        /// </summary>
        [XmlElement("prin_amt")]
        public string PrinAmt { get; set; }

        /// <summary>
        /// 账单备注信息
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 当期账单状态，可以选择的枚举值为：正常(NORMAL)，已结清(CLEAR)，逾期(OVERDUE), 已处置（DISPOSAL）
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 期数，只能填写大于0的数字
        /// </summary>
        [XmlElement("term")]
        public string Term { get; set; }

        /// <summary>
        /// 应还总金额，单位分
        /// </summary>
        [XmlElement("total_amt")]
        public string TotalAmt { get; set; }
    }
}
