using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KbdishAreaFreeInfo Data Structure.
    /// </summary>
    [Serializable]
    public class KbdishAreaFreeInfo : AopObject
    {
        /// <summary>
        /// 餐区id
        /// </summary>
        [XmlElement("area_id")]
        public string AreaId { get; set; }

        /// <summary>
        /// 份数
        /// </summary>
        [XmlElement("count")]
        public string Count { get; set; }

        /// <summary>
        /// 口碑菜品id
        /// </summary>
        [XmlElement("dish_id")]
        public string DishId { get; set; }

        /// <summary>
        /// sku_id
        /// </summary>
        [XmlElement("dish_sku_id")]
        public string DishSkuId { get; set; }

        /// <summary>
        /// open 启动 stop 停用
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }
    }
}
