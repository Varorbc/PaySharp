using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiMarketingCampaignOpenDeliveryCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiMarketingCampaignOpenDeliveryCreateModel : AopObject
    {
        /// <summary>
        /// 详情设置会根据delivery_type字段类型不同而格式不同，整体是json结构。详细说明见链接：https://lark.alipay.com/xiaoling.zwt/idg11s/mhx33i
        /// </summary>
        [XmlElement("delivery_content")]
        public string DeliveryContent { get; set; }

        /// <summary>
        /// 店铺页投放内容的类型。目前支持的类型有：1. gift_card
        /// </summary>
        [XmlElement("delivery_type")]
        public string DeliveryType { get; set; }

        /// <summary>
        /// 商户的PID
        /// </summary>
        [XmlElement("partner_id")]
        public string PartnerId { get; set; }

        /// <summary>
        /// 内容投放的门店ID
        /// </summary>
        [XmlElement("shop_id")]
        public string ShopId { get; set; }
    }
}
