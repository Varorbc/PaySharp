using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// DishRecommend Data Structure.
    /// </summary>
    [Serializable]
    public class DishRecommend : AopObject
    {
        /// <summary>
        /// 购买可能性/商品热度得分  若type=CART_RECOMAND or DESIGN_FOR_YOU；则 buy_posibility有返回，内容为商品热度得分。  若type= ASSOCIATION_RECOMAND；则 buy_posibility有返回，内容为购买可能性。  若type=QUICK_ORDER；则 buy_posibility无返回。
        /// </summary>
        [XmlElement("buy_posibility")]
        public string BuyPosibility { get; set; }

        /// <summary>
        /// 菜品ID
        /// </summary>
        [XmlElement("dish_id")]
        public string DishId { get; set; }

        /// <summary>
        /// 菜品名称
        /// </summary>
        [XmlElement("dish_name")]
        public string DishName { get; set; }

        /// <summary>
        /// 10
        /// </summary>
        [XmlElement("dish_num")]
        public string DishNum { get; set; }

        /// <summary>
        /// 1234
        /// </summary>
        [XmlElement("dish_skuid")]
        public string DishSkuid { get; set; }

        /// <summary>
        /// 推荐理由对应的CODE
        /// </summary>
        [XmlElement("info_code")]
        public string InfoCode { get; set; }
    }
}
