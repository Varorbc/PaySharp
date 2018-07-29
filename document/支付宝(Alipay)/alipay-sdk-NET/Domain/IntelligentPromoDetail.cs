using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// IntelligentPromoDetail Data Structure.
    /// </summary>
    [Serializable]
    public class IntelligentPromoDetail : AopObject
    {
        /// <summary>
        /// 活动预算
        /// </summary>
        [XmlElement("budget")]
        public BudgetInfo Budget { get; set; }

        /// <summary>
        /// 营销活动的id，也就是消费送的活动id
        /// </summary>
        [XmlElement("camp_id")]
        public string CampId { get; set; }

        /// <summary>
        /// 活动限制信息
        /// </summary>
        [XmlElement("constraint")]
        public ConstraintInfo Constraint { get; set; }

        /// <summary>
        /// 圈人限制条件
        /// </summary>
        [XmlElement("crowd_constraint")]
        public CrowdConstraintInfo CrowdConstraint { get; set; }

        /// <summary>
        /// 智能营销活动的子活动
        /// </summary>
        [XmlElement("desc")]
        public string Desc { get; set; }

        /// <summary>
        /// 活动扩展信息
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 营销活动预测效果
        /// </summary>
        [XmlElement("forecast_effect")]
        public IntelligentPromoEffect ForecastEffect { get; set; }

        /// <summary>
        /// 自运营活动类型。DIRECT_SEND：直发奖；CONSUME_SEND：消费送
        /// </summary>
        [XmlElement("merchant_promo_type")]
        public string MerchantPromoType { get; set; }

        /// <summary>
        /// 子营销活动名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 营销工具集合。主要是活动涉及到的奖品信息
        /// </summary>
        [XmlArray("promo_tools")]
        [XmlArrayItem("promo_tool")]
        public List<PromoTool> PromoTools { get; set; }

        /// <summary>
        /// 投放渠道信息
        /// </summary>
        [XmlArray("publish_channels")]
        [XmlArrayItem("publish_channel")]
        public List<PublishChannel> PublishChannels { get; set; }

        /// <summary>
        /// 子营销活动对应的模板id
        /// </summary>
        [XmlElement("template_id")]
        public string TemplateId { get; set; }
    }
}
