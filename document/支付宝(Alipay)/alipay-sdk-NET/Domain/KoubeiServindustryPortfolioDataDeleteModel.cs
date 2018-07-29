using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiServindustryPortfolioDataDeleteModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiServindustryPortfolioDataDeleteModel : AopObject
    {
        /// <summary>
        /// 作品集id
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
