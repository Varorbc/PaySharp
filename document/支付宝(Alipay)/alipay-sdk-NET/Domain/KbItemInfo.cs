using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KbItemInfo Data Structure.
    /// </summary>
    [Serializable]
    public class KbItemInfo : AopObject
    {
        /// <summary>
        /// 店铺人气值，共4个等级,1,2,3,4
        /// </summary>
        [XmlElement("avg_pop_value")]
        public string AvgPopValue { get; set; }

        /// <summary>
        /// 开卖时间
        /// </summary>
        [XmlElement("begin_time")]
        public string BeginTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [XmlElement("end_time")]
        public string EndTime { get; set; }

        /// <summary>
        /// 扩展信息，json格式
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// 商品logo图片
        /// </summary>
        [XmlElement("logo")]
        public string Logo { get; set; }

        /// <summary>
        /// 商品原价。
        /// </summary>
        [XmlElement("original_price")]
        public string OriginalPrice { get; set; }

        /// <summary>
        /// 当前库存
        /// </summary>
        [XmlElement("quota")]
        public string Quota { get; set; }

        /// <summary>
        /// 优惠价
        /// </summary>
        [XmlElement("sale_price")]
        public string SalePrice { get; set; }

        /// <summary>
        /// 商品所属店铺距离当前用户距离
        /// </summary>
        [XmlElement("shop_distance")]
        public string ShopDistance { get; set; }

        /// <summary>
        /// 商品所属店铺ID
        /// </summary>
        [XmlElement("shop_id")]
        public string ShopId { get; set; }

        /// <summary>
        /// 商品所属店铺名称
        /// </summary>
        [XmlElement("shop_name")]
        public string ShopName { get; set; }

        /// <summary>
        /// 商品状态，SOLD_OUT：售罄，SELL_ING：进行中
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 商品标题
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// 是否置顶，1：置顶，0:非置顶
        /// </summary>
        [XmlElement("top")]
        public string Top { get; set; }

        /// <summary>
        /// 总库存
        /// </summary>
        [XmlElement("total_quota")]
        public string TotalQuota { get; set; }

        /// <summary>
        /// 商品详情页地址
        /// </summary>
        [XmlElement("url")]
        public string Url { get; set; }
    }
}
