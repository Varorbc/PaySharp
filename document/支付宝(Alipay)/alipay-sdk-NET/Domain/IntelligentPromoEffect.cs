using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// IntelligentPromoEffect Data Structure.
    /// </summary>
    [Serializable]
    public class IntelligentPromoEffect : AopObject
    {
        /// <summary>
        /// 平均客单价提升比例
        /// </summary>
        [XmlElement("avg_prize_increase")]
        public string AvgPrizeIncrease { get; set; }

        /// <summary>
        /// 成本
        /// </summary>
        [XmlElement("cost")]
        public string Cost { get; set; }

        /// <summary>
        /// 当前效益
        /// </summary>
        [XmlElement("current_total_amount")]
        public string CurrentTotalAmount { get; set; }

        /// <summary>
        /// 营销活动的预期效果id
        /// </summary>
        [XmlElement("effect_id")]
        public string EffectId { get; set; }

        /// <summary>
        /// 时间范围左值
        /// </summary>
        [XmlElement("gmt_from")]
        public string GmtFrom { get; set; }

        /// <summary>
        /// 时间范围右值
        /// </summary>
        [XmlElement("gmt_to")]
        public string GmtTo { get; set; }

        /// <summary>
        /// 成交额
        /// </summary>
        [XmlElement("gmv")]
        public string Gmv { get; set; }

        /// <summary>
        /// 剩余库存数
        /// </summary>
        [XmlElement("remain_stock_num")]
        public long RemainStockNum { get; set; }

        /// <summary>
        /// 复购率提升比例
        /// </summary>
        [XmlElement("repay_rate_increase")]
        public string RepayRateIncrease { get; set; }

        /// <summary>
        /// 发券量提升比例
        /// </summary>
        [XmlElement("send_count_increase")]
        public string SendCountIncrease { get; set; }

        /// <summary>
        /// 发券数量
        /// </summary>
        [XmlElement("take_count")]
        public long TakeCount { get; set; }

        /// <summary>
        /// 营销活动效果类型。FORECAST：预估；STATISTICS：统计
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }

        /// <summary>
        /// 核销量
        /// </summary>
        [XmlElement("use_count")]
        public long UseCount { get; set; }
    }
}
