using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// Category Data Structure.
    /// </summary>
    [Serializable]
    public class Category : AopObject
    {
        /// <summary>
        /// 店铺分类ID集合
        /// </summary>
        [XmlArray("shop_cate_ids")]
        [XmlArrayItem("string")]
        public List<string> ShopCateIds { get; set; }

        /// <summary>
        /// 美食/娱乐等分类条目
        /// </summary>
        [XmlElement("shop_cate_name")]
        public string ShopCateName { get; set; }
    }
}
