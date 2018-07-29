using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayMarketingToolFengdieSpaceBatchqueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayMarketingToolFengdieSpaceBatchqueryModel : AopObject
    {
        /// <summary>
        /// 当前页数，默认为1
        /// </summary>
        [XmlElement("page_number")]
        public long PageNumber { get; set; }

        /// <summary>
        /// 每页记录数，不能超过50，默认为10
        /// </summary>
        [XmlElement("page_size")]
        public long PageSize { get; set; }
    }
}
