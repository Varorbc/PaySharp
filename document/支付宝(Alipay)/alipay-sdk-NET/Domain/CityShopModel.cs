using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// CityShopModel Data Structure.
    /// </summary>
    [Serializable]
    public class CityShopModel : AopObject
    {
        /// <summary>
        /// 城市id
        /// </summary>
        [XmlElement("city_id")]
        public string CityId { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        [XmlElement("city_name")]
        public string CityName { get; set; }

        /// <summary>
        /// 区id
        /// </summary>
        [XmlElement("district_id")]
        public string DistrictId { get; set; }

        /// <summary>
        /// 区名称
        /// </summary>
        [XmlElement("district_name")]
        public string DistrictName { get; set; }

        /// <summary>
        /// 判断门店是否是简易门店
        /// </summary>
        [XmlElement("pos_shop")]
        public bool PosShop { get; set; }

        /// <summary>
        /// 省份id
        /// </summary>
        [XmlElement("province_id")]
        public string ProvinceId { get; set; }

        /// <summary>
        /// 省份名称
        /// </summary>
        [XmlElement("province_name")]
        public string ProvinceName { get; set; }

        /// <summary>
        /// 门店id
        /// </summary>
        [XmlElement("shop_id")]
        public string ShopId { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>
        [XmlElement("shop_name")]
        public string ShopName { get; set; }

        /// <summary>
        /// 门店状态
        /// </summary>
        [XmlElement("shop_status")]
        public string ShopStatus { get; set; }
    }
}
