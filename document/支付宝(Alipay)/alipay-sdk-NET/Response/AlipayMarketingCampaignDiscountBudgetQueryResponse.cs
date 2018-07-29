using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayMarketingCampaignDiscountBudgetQueryResponse.
    /// </summary>
    public class AlipayMarketingCampaignDiscountBudgetQueryResponse : AopResponse
    {
        /// <summary>
        /// 预算ID
        /// </summary>
        [XmlElement("budget_id")]
        public string BudgetId { get; set; }

        /// <summary>
        /// 预算剩余冻结金额(元)
        /// </summary>
        [XmlElement("freeze_amount")]
        public string FreezeAmount { get; set; }

        /// <summary>
        /// 预算已回收退回保证金账户金额(元)
        /// </summary>
        [XmlElement("recycle_amount")]
        public string RecycleAmount { get; set; }

        /// <summary>
        /// 交易已退款金额(元)
        /// </summary>
        [XmlElement("refund_amount")]
        public string RefundAmount { get; set; }

        /// <summary>
        /// 预算总金额(元)
        /// </summary>
        [XmlElement("total_amount")]
        public string TotalAmount { get; set; }

        /// <summary>
        /// 交易已使用金额(元)
        /// </summary>
        [XmlElement("used_amount")]
        public string UsedAmount { get; set; }
    }
}
