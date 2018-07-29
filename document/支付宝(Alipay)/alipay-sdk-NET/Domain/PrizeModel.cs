using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// PrizeModel Data Structure.
    /// </summary>
    [Serializable]
    public class PrizeModel : AopObject
    {
        /// <summary>
        /// 生效时间
        /// </summary>
        [XmlElement("active_time")]
        public string ActiveTime { get; set; }

        /// <summary>
        /// 可用金额，单位元，精度分
        /// </summary>
        [XmlElement("available_amount")]
        public string AvailableAmount { get; set; }

        /// <summary>
        /// 可用次数，大于1为可找零红包，等于1为不找零红包
        /// </summary>
        [XmlElement("available_count")]
        public long AvailableCount { get; set; }

        /// <summary>
        /// 奖品描述
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// 按天折扣信息
        /// </summary>
        [XmlArray("discount_by_day_list")]
        [XmlArrayItem("discount_by_day_model")]
        public List<DiscountByDayModel> DiscountByDayList { get; set; }

        /// <summary>
        /// 分期和整笔折扣信息
        /// </summary>
        [XmlArray("discount_list")]
        [XmlArrayItem("discount_model")]
        public List<DiscountModel> DiscountList { get; set; }

        /// <summary>
        /// 失效时间
        /// </summary>
        [XmlElement("expired_time")]
        public string ExpiredTime { get; set; }

        /// <summary>
        /// 扩展信息，JSON结构
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 奖品名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 奖品的复合ID
        /// </summary>
        [XmlElement("prize_id")]
        public string PrizeId { get; set; }

        /// <summary>
        /// 奖品状态  VALID 可使用  EXPIRED 已过期  ALL_USED 全部使用完
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 总金额，单位元，精度分
        /// </summary>
        [XmlElement("total_amount")]
        public string TotalAmount { get; set; }

        /// <summary>
        /// 奖品类型  DISCOUNT_VOUCHER 利率打折卡券  COUPON_VOUCHER 利息红包卡券  DISCOUNT_CAMP 实时优惠活动
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }

        /// <summary>
        /// 已使用次数
        /// </summary>
        [XmlElement("used_count")]
        public long UsedCount { get; set; }
    }
}
