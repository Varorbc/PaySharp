using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Aop.Api.Domain;

namespace Aop.Api.Response
{
    /// <summary>
    /// KoubeiMarketingCampaignIntelligentPromoBatchqueryResponse.
    /// </summary>
    public class KoubeiMarketingCampaignIntelligentPromoBatchqueryResponse : AopResponse
    {
        /// <summary>
        /// 查询返回的营销活动列表信息
        /// </summary>
        [XmlArray("intelligent_promos")]
        [XmlArrayItem("intelligent_promo")]
        public List<IntelligentPromo> IntelligentPromos { get; set; }

        /// <summary>
        /// 查询后返回的分页信息
        /// </summary>
        [XmlElement("page_result")]
        public PromoPageResult PageResult { get; set; }
    }
}
