using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KbdishGroupDetailInfo Data Structure.
    /// </summary>
    [Serializable]
    public class KbdishGroupDetailInfo : AopObject
    {
        /// <summary>
        /// 组下明细的加价单价 例如加2元 加3元
        /// </summary>
        [XmlElement("add_price")]
        public string AddPrice { get; set; }

        /// <summary>
        /// 明细菜品在套餐里的个数,
        /// </summary>
        [XmlElement("detail_count")]
        public string DetailCount { get; set; }

        /// <summary>
        /// 菜品id
        /// </summary>
        [XmlElement("detail_dish_id")]
        public string DetailDishId { get; set; }

        /// <summary>
        /// 组下面的菜品是否默认 Y/N
        /// </summary>
        [XmlElement("detail_is_default")]
        public string DetailIsDefault { get; set; }

        /// <summary>
        /// 分组下包含的明细菜品的dish_code
        /// </summary>
        [XmlElement("detail_sku_id")]
        public string DetailSkuId { get; set; }

        /// <summary>
        /// 排序字典
        /// </summary>
        [XmlElement("detail_sort")]
        public string DetailSort { get; set; }

        /// <summary>
        /// 组id
        /// </summary>
        [XmlElement("group_id")]
        public string GroupId { get; set; }
    }
}
