using System;
using System.Xml.Serialization;
using Aop.Api.Domain;

namespace Aop.Api.Response
{
    /// <summary>
    /// KoubeiAdvertDeliveryDiscountGetResponse.
    /// </summary>
    public class KoubeiAdvertDeliveryDiscountGetResponse : AopResponse
    {
        /// <summary>
        /// 广告推荐的商品信息列表，个数小于等于请求中参数“size”个数
        /// </summary>
        [XmlElement("discounts")]
        public DiscountInfo Discounts { get; set; }

        /// <summary>
        /// 本次推荐的唯一标识， 此字段需回传
        /// </summary>
        [XmlElement("recommend_id")]
        public string RecommendId { get; set; }
    }
}
