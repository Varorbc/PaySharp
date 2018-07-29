using System;
using System.Xml.Serialization;
using Aop.Api.Domain;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayEbppInvoiceTitleDynamicGetResponse.
    /// </summary>
    public class AlipayEbppInvoiceTitleDynamicGetResponse : AopResponse
    {
        /// <summary>
        /// 发票抬头
        /// </summary>
        [XmlElement("title")]
        public InvoiceTitleModel Title { get; set; }
    }
}
