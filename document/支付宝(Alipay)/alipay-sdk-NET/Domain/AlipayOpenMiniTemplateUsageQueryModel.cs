using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenMiniTemplateUsageQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenMiniTemplateUsageQueryModel : AopObject
    {
        /// <summary>
        /// 查询的页数，默认第一页
        /// </summary>
        [XmlElement("page_num")]
        public long PageNum { get; set; }

        /// <summary>
        /// 每页的数量，最多查询50个，默认查询10个
        /// </summary>
        [XmlElement("page_size")]
        public long PageSize { get; set; }

        /// <summary>
        /// 模板id
        /// </summary>
        [XmlElement("template_id")]
        public string TemplateId { get; set; }

        /// <summary>
        /// 模板小程序的版本号
        /// </summary>
        [XmlElement("template_version")]
        public string TemplateVersion { get; set; }
    }
}
