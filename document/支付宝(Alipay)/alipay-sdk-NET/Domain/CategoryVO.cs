using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// CategoryVO Data Structure.
    /// </summary>
    [Serializable]
    public class CategoryVO : AopObject
    {
        /// <summary>
        /// 类目ID
        /// </summary>
        [XmlElement("category_id")]
        public string CategoryId { get; set; }

        /// <summary>
        /// 类目名称
        /// </summary>
        [XmlElement("category_name")]
        public string CategoryName { get; set; }

        /// <summary>
        /// 类目描述
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// 1表示有效，0表示无效
        /// </summary>
        [XmlElement("enable")]
        public long Enable { get; set; }

        /// <summary>
        /// 类目层级
        /// </summary>
        [XmlElement("level")]
        public string Level { get; set; }

        /// <summary>
        /// 父类目ID
        /// </summary>
        [XmlElement("parent_id")]
        public string ParentId { get; set; }

        /// <summary>
        /// 根类目ID
        /// </summary>
        [XmlElement("root_id")]
        public string RootId { get; set; }
    }
}
