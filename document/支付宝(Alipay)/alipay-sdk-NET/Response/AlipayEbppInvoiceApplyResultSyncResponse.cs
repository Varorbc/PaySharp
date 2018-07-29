using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayEbppInvoiceApplyResultSyncResponse.
    /// </summary>
    public class AlipayEbppInvoiceApplyResultSyncResponse : AopResponse
    {
        /// <summary>
        /// 标注是否需要调用方重试，在请求失败的情况下返回，如果该字段返回true表明该失败的情况通过重试补偿可解决，为false表明失败情况通过重试无法解决
        /// </summary>
        [XmlElement("retry_flag")]
        public bool RetryFlag { get; set; }
    }
}
