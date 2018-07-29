using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenPublicXwbtestabcdBatchqueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenPublicXwbtestabcdBatchqueryModel : AopObject
    {
        /// <summary>
        /// 1111112141414
        /// </summary>
        [XmlElement("s")]
        public string S { get; set; }
    }
}
