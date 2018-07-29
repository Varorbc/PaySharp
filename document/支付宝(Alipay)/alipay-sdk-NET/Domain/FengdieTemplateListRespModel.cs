using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// FengdieTemplateListRespModel Data Structure.
    /// </summary>
    [Serializable]
    public class FengdieTemplateListRespModel : AopObject
    {
        /// <summary>
        /// 云凤蝶模板包列表，包含了多个模板信息，模板信息中包含了模板名称、模板拥有者等信息
        /// </summary>
        [XmlArray("list")]
        [XmlArrayItem("fengdie_template_detail_model")]
        public List<FengdieTemplateDetailModel> List { get; set; }

        /// <summary>
        /// 返回的分页数据信息，包括项目总数、当前页数、总页数等信息
        /// </summary>
        [XmlElement("paginator")]
        public FengdieListPaginator Paginator { get; set; }
    }
}
