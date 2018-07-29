using System;
using System.Xml.Serialization;
using Aop.Api.Domain;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayMarketingToolFengdieTemplateBatchqueryResponse.
    /// </summary>
    public class AlipayMarketingToolFengdieTemplateBatchqueryResponse : AopResponse
    {
        /// <summary>
        /// 模板详情列表
        /// </summary>
        [XmlElement("data")]
        public FengdieTemplateListRespModel Data { get; set; }
    }
}
