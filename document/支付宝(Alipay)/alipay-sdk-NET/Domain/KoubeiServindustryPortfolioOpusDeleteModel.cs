using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiServindustryPortfolioOpusDeleteModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiServindustryPortfolioOpusDeleteModel : AopObject
    {
        /// <summary>
        /// 作品ID列表
        /// </summary>
        [XmlArray("opus_ids")]
        [XmlArrayItem("string")]
        public List<string> OpusIds { get; set; }

        /// <summary>
        /// 操作人信息
        /// </summary>
        [XmlElement("portfolio_operator_info")]
        public PortfolioOperatorInfo PortfolioOperatorInfo { get; set; }
    }
}
