using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// QuoteInfo Data Structure.
    /// </summary>
    [Serializable]
    public class QuoteInfo : AopObject
    {
        /// <summary>
        /// 238810000000049704774
        /// </summary>
        [XmlElement("company_id")]
        public string CompanyId { get; set; }

        /// <summary>
        /// 报价ID
        /// </summary>
        [XmlElement("quote_biz_id")]
        public string QuoteBizId { get; set; }
    }
}
