using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiCateringDishAreaQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiCateringDishAreaQueryModel : AopObject
    {
        /// <summary>
        /// 餐区id
        /// </summary>
        [XmlElement("area_id")]
        public string AreaId { get; set; }

        /// <summary>
        /// 餐区名称
        /// </summary>
        [XmlElement("area_name")]
        public string AreaName { get; set; }

        /// <summary>
        /// 商户id
        /// </summary>
        [XmlElement("merchant_id")]
        public string MerchantId { get; set; }

        /// <summary>
        /// 门店id 支付宝的
        /// </summary>
        [XmlElement("shop_id")]
        public string ShopId { get; set; }

        /// <summary>
        /// open 启动 stop 停用
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 餐台id  根据餐台反查到餐区，再返回全模型
        /// </summary>
        [XmlElement("tab_id")]
        public string TabId { get; set; }
    }
}
