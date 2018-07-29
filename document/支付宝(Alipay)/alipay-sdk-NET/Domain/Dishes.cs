using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// Dishes Data Structure.
    /// </summary>
    [Serializable]
    public class Dishes : AopObject
    {
        /// <summary>
        /// 外部菜品ID  当dish_list[]不为空的时候，dish_id是必填字段。
        /// </summary>
        [XmlElement("dish_id")]
        public string DishId { get; set; }

        /// <summary>
        /// 菜品名称
        /// </summary>
        [XmlElement("dish_name")]
        public string DishName { get; set; }

        /// <summary>
        /// 菜品数量
        /// </summary>
        [XmlElement("dish_num")]
        public string DishNum { get; set; }

        /// <summary>
        /// 菜品价格（单位分）
        /// </summary>
        [XmlElement("dish_price")]
        public string DishPrice { get; set; }

        /// <summary>
        /// 菜品折后价格（单位分）
        /// </summary>
        [XmlElement("dish_real_price")]
        public string DishRealPrice { get; set; }

        /// <summary>
        /// 1234
        /// </summary>
        [XmlElement("dish_skuid")]
        public string DishSkuid { get; set; }
    }
}
