using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiMarketingDataMallRecommendGetModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiMarketingDataMallRecommendGetModel : AopObject
    {
        /// <summary>
        /// 获取几条数据，最大值传入50，默认值10
        /// </summary>
        [XmlElement("count")]
        public long Count { get; set; }

        /// <summary>
        /// 获取的数据类型:big_item(商圈商品)、small_item(商圈下门店商品)、big_voucher(商圈券)、small_voucher(商圈下门店券)
        /// </summary>
        [XmlElement("data_type")]
        public string DataType { get; set; }

        /// <summary>
        /// 设备ID
        /// </summary>
        [XmlElement("device_id")]
        public string DeviceId { get; set; }

        /// <summary>
        /// 商圈ID
        /// </summary>
        [XmlElement("mall_id")]
        public string MallId { get; set; }

        /// <summary>
        /// 店铺类目ID
        /// </summary>
        [XmlArray("shop_category_ids")]
        [XmlArrayItem("string")]
        public List<string> ShopCategoryIds { get; set; }

        /// <summary>
        /// 起始数据下标，默认值0
        /// </summary>
        [XmlElement("start")]
        public long Start { get; set; }

        /// <summary>
        /// 支付宝用户ID
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
