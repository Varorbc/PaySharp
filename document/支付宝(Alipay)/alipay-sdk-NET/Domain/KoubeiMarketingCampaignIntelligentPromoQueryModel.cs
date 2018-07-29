using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiMarketingCampaignIntelligentPromoQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiMarketingCampaignIntelligentPromoQueryModel : AopObject
    {
        /// <summary>
        /// 操作人员上下文
        /// </summary>
        [XmlElement("operator_context")]
        public PromoOperatorInfo OperatorContext { get; set; }

        /// <summary>
        /// 外部业务id，请保持足够复杂。主要为了定位数据来源
        /// </summary>
        [XmlElement("out_request_no")]
        public string OutRequestNo { get; set; }

        /// <summary>
        /// 智能营销活动id
        /// </summary>
        [XmlElement("promo_id")]
        public string PromoId { get; set; }
    }
}
