using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// InteligentUseRule Data Structure.
    /// </summary>
    [Serializable]
    public class InteligentUseRule : AopObject
    {
        /// <summary>
        /// 券的不可用时间
        /// </summary>
        [XmlElement("inteligent_forbidden_time")]
        public InteligentForbiddenTime InteligentForbiddenTime { get; set; }

        /// <summary>
        /// 券可用时间段
        /// </summary>
        [XmlArray("inteligent_use_times")]
        [XmlArrayItem("inteligent_use_time")]
        public List<InteligentUseTime> InteligentUseTimes { get; set; }

        /// <summary>
        /// 优惠券的使用支付渠道限制规  则，  不受支付渠道限制  :USE_NO_LIMIT;  仅限口碑储值卡支付时可用  :USE_ON_CURRENT_PAY_C  HANNEL;  口碑储值卡支付时不可用  :NOT_ALLOWED_USE;  【备注】支付渠道限制不允许修改
        /// </summary>
        [XmlElement("limit_rule")]
        public string LimitRule { get; set; }

        /// <summary>
        /// 券核销的最低消费门槛，单位元
        /// </summary>
        [XmlElement("min_consume")]
        public string MinConsume { get; set; }

        /// <summary>
        /// 核券门槛-最低消费金额-推荐约束；  提供推荐方案参数可调区间范围, 为空则认为不可调
        /// </summary>
        [XmlElement("min_consume_condition")]
        public InteligentDataCondition MinConsumeCondition { get; set; }

        /// <summary>
        /// 券买单跳转链接
        /// </summary>
        [XmlElement("pay_redirect_url")]
        public string PayRedirectUrl { get; set; }

        /// <summary>
        /// 券适用门店列表  仅品牌商发起的招商活动可为空  直发奖类型活动必须与活动适用门店一致  最多支持10w家门店
        /// </summary>
        [XmlArray("suit_shops")]
        [XmlArrayItem("string")]
        public List<string> SuitShops { get; set; }
    }
}
