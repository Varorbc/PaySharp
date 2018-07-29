using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenDataItemRecommendBatchqueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenDataItemRecommendBatchqueryModel : AopObject
    {
        /// <summary>
        /// 国家地区行政编码
        /// </summary>
        [XmlElement("area_code")]
        public string AreaCode { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 展位ID,支持批量咨询，多个展位用逗号分隔
        /// </summary>
        [XmlElement("position_ids")]
        public string PositionIds { get; set; }

        /// <summary>
        /// 用户的支付宝UID
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
