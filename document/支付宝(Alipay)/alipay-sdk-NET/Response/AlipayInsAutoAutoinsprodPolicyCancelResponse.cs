using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayInsAutoAutoinsprodPolicyCancelResponse.
    /// </summary>
    public class AlipayInsAutoAutoinsprodPolicyCancelResponse : AopResponse
    {
        /// <summary>
        /// 操作结果 true/false
        /// </summary>
        [XmlElement("cancel_result")]
        public string CancelResult { get; set; }
    }
}
