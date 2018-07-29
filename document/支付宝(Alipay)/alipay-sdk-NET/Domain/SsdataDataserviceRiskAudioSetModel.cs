using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// SsdataDataserviceRiskAudioSetModel Data Structure.
    /// </summary>
    [Serializable]
    public class SsdataDataserviceRiskAudioSetModel : AopObject
    {
        /// <summary>
        /// 关键词创建人，也即使用者
        /// </summary>
        [XmlElement("creator")]
        public string Creator { get; set; }

        /// <summary>
        /// 要删除的关键词id
        /// </summary>
        [XmlArray("id_list")]
        [XmlArrayItem("string")]
        public List<string> IdList { get; set; }

        /// <summary>
        /// 新增或查询的关键词。新增时，可以传多个用以批量新增；查询时候，可以不传或只传一个。
        /// </summary>
        [XmlArray("keyword_list")]
        [XmlArrayItem("string")]
        public List<string> KeywordList { get; set; }

        /// <summary>
        /// 修改人，一般的修改指的是删除
        /// </summary>
        [XmlElement("modifier")]
        public string Modifier { get; set; }

        /// <summary>
        /// add 表示新增；delete 表示删除；query 表示查询；
        /// </summary>
        [XmlElement("operate_type")]
        public string OperateType { get; set; }

        /// <summary>
        /// 页数
        /// </summary>
        [XmlElement("page_num")]
        public string PageNum { get; set; }

        /// <summary>
        /// 一页展示数量
        /// </summary>
        [XmlElement("page_size")]
        public string PageSize { get; set; }

        /// <summary>
        /// 关键词风险类型，批量增加时候，该批关键词为同一风险类型。1-涉政，2-涉黄
        /// </summary>
        [XmlElement("risk_type")]
        public string RiskType { get; set; }
    }
}
