using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KbdishCookDetailInfo Data Structure.
    /// </summary>
    [Serializable]
    public class KbdishCookDetailInfo : AopObject
    {
        /// <summary>
        /// 菜谱大类
        /// </summary>
        [XmlElement("catetory_big_id")]
        public string CatetoryBigId { get; set; }

        /// <summary>
        /// 菜谱小类
        /// </summary>
        [XmlElement("catetory_small_id")]
        public string CatetorySmallId { get; set; }

        /// <summary>
        /// 菜谱id
        /// </summary>
        [XmlElement("cook_id")]
        public string CookId { get; set; }

        /// <summary>
        /// 菜品id
        /// </summary>
        [XmlElement("dish_id")]
        public string DishId { get; set; }

        /// <summary>
        /// 打标
        /// </summary>
        [XmlElement("flag")]
        public string Flag { get; set; }

        /// <summary>
        /// 价格明细
        /// </summary>
        [XmlArray("kb_cook_sku_price_list")]
        [XmlArrayItem("kbdish_cook_price_info")]
        public List<KbdishCookPriceInfo> KbCookSkuPriceList { get; set; }

        /// <summary>
        /// 排序值
        /// </summary>
        [XmlElement("sort")]
        public string Sort { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }
    }
}
