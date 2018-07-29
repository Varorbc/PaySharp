using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// FengdieListPaginator Data Structure.
    /// </summary>
    [Serializable]
    public class FengdieListPaginator : AopObject
    {
        /// <summary>
        /// 总页数
        /// </summary>
        [XmlElement("page_count")]
        public long PageCount { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        [XmlElement("page_number")]
        public long PageNumber { get; set; }

        /// <summary>
        /// 每页显示记录数
        /// </summary>
        [XmlElement("page_size")]
        public long PageSize { get; set; }

        /// <summary>
        /// 符合条件的记录总数
        /// </summary>
        [XmlElement("total")]
        public long Total { get; set; }
    }
}
