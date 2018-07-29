using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// RetailItemDescription Data Structure.
    /// </summary>
    [Serializable]
    public class RetailItemDescription : AopObject
    {
        /// <summary>
        /// 标题下的描述列表，列表类型，每项不得超过100个中文字符,最多10项
        /// </summary>
        [XmlArray("details")]
        [XmlArrayItem("string")]
        public List<string> Details { get; set; }

        /// <summary>
        /// 商品描述title
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }
    }
}
