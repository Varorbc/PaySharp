using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiRetailWmsProducerQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiRetailWmsProducerQueryModel : AopObject
    {
        /// <summary>
        /// 页码，分页参数，默认1。
        /// </summary>
        [XmlElement("page_no")]
        public long PageNo { get; set; }

        /// <summary>
        /// 页面大小，分页参数，默认20
        /// </summary>
        [XmlElement("page_size")]
        public long PageSize { get; set; }
    }
}
