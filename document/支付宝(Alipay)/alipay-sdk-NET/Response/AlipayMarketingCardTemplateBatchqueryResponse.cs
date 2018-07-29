using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Aop.Api.Domain;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayMarketingCardTemplateBatchqueryResponse.
    /// </summary>
    public class AlipayMarketingCardTemplateBatchqueryResponse : AopResponse
    {
        /// <summary>
        /// 会员卡模板基本信息
        /// </summary>
        [XmlArray("mcard_template")]
        [XmlArrayItem("mcard_template")]
        public List<McardTemplate> McardTemplate { get; set; }

        /// <summary>
        /// 会员卡模板总数
        /// </summary>
        [XmlElement("template_total")]
        public long TemplateTotal { get; set; }
    }
}
