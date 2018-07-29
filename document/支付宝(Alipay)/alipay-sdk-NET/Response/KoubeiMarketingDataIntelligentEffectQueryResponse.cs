using System;
using System.Xml.Serialization;
using Aop.Api.Domain;

namespace Aop.Api.Response
{
    /// <summary>
    /// KoubeiMarketingDataIntelligentEffectQueryResponse.
    /// </summary>
    public class KoubeiMarketingDataIntelligentEffectQueryResponse : AopResponse
    {
        /// <summary>
        /// 咨询后返回的模型，包含活动本身的模型以及效果模型
        /// </summary>
        [XmlElement("promo")]
        public IntelligentPromo Promo { get; set; }
    }
}
