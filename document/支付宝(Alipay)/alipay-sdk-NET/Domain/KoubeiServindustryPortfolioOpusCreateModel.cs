using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiServindustryPortfolioOpusCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiServindustryPortfolioOpusCreateModel : AopObject
    {
        /// <summary>
        /// ISV插件ID
        /// </summary>
        [XmlElement("commodity_id")]
        public string CommodityId { get; set; }

        /// <summary>
        /// 作品列表信息
        /// </summary>
        [XmlArray("opuses")]
        [XmlArrayItem("opus_info")]
        public List<OpusInfo> Opuses { get; set; }

        /// <summary>
        /// 作品集ID
        /// </summary>
        [XmlElement("portfolio_id")]
        public string PortfolioId { get; set; }

        /// <summary>
        /// 操作人信息
        /// </summary>
        [XmlElement("portfolio_operator_info")]
        public PortfolioOperatorInfo PortfolioOperatorInfo { get; set; }
    }
}
