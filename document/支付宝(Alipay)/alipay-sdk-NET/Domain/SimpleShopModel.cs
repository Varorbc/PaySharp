using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// SimpleShopModel Data Structure.
    /// </summary>
    [Serializable]
    public class SimpleShopModel : AopObject
    {
        /// <summary>
        /// 商户门店id
        /// </summary>
        [XmlElement("shop_id")]
        public string ShopId { get; set; }

        /// <summary>
        /// 商户门店名称
        /// </summary>
        [XmlElement("shop_name")]
        public string ShopName { get; set; }
    }
}
