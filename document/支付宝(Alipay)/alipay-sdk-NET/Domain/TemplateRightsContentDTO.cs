using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// TemplateRightsContentDTO Data Structure.
    /// </summary>
    [Serializable]
    public class TemplateRightsContentDTO : AopObject
    {
        /// <summary>
        /// 权益内容详情
        /// </summary>
        [XmlElement("detail")]
        public string Detail { get; set; }

        /// <summary>
        /// 权益内容标题
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }
    }
}
