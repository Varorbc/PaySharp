using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayOpenPublicMessageContentCreateResponse.
    /// </summary>
    public class AlipayOpenPublicMessageContentCreateResponse : AopResponse
    {
        /// <summary>
        /// 内容id
        /// </summary>
        [XmlElement("content_id")]
        public string ContentId { get; set; }

        /// <summary>
        /// 内容详情内链url
        /// </summary>
        [XmlElement("content_url")]
        public string ContentUrl { get; set; }
    }
}
