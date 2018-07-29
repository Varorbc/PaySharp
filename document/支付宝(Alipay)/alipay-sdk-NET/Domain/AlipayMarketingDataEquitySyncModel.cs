using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayMarketingDataEquitySyncModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayMarketingDataEquitySyncModel : AopObject
    {
        /// <summary>
        /// biz_time
        /// </summary>
        [XmlElement("biz_time")]
        public string BizTime { get; set; }

        /// <summary>
        /// equity_code
        /// </summary>
        [XmlElement("equity_code")]
        public string EquityCode { get; set; }

        /// <summary>
        /// equity_from
        /// </summary>
        [XmlElement("equity_from")]
        public string EquityFrom { get; set; }

        /// <summary>
        /// equity_id
        /// </summary>
        [XmlElement("equity_id")]
        public string EquityId { get; set; }

        /// <summary>
        /// equity_info
        /// </summary>
        [XmlElement("equity_info")]
        public EquityInfo EquityInfo { get; set; }

        /// <summary>
        /// original_biz_no
        /// </summary>
        [XmlElement("original_biz_no")]
        public string OriginalBizNo { get; set; }

        /// <summary>
        /// original_biz_type
        /// </summary>
        [XmlElement("original_biz_type")]
        public string OriginalBizType { get; set; }

        /// <summary>
        /// out_biz_no
        /// </summary>
        [XmlElement("out_biz_no")]
        public string OutBizNo { get; set; }

        /// <summary>
        /// 支付宝userid
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
