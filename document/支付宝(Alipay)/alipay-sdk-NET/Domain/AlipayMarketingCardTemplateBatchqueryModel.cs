using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayMarketingCardTemplateBatchqueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayMarketingCardTemplateBatchqueryModel : AopObject
    {
        /// <summary>
        /// 页码
        /// </summary>
        [XmlElement("page_no")]
        public long PageNo { get; set; }

        /// <summary>
        /// 每页大小，默认20条，最大支持20条
        /// </summary>
        [XmlElement("page_size")]
        public long PageSize { get; set; }
    }
}
