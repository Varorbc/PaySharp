using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayInsCooperationProductOfflineBatchqueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayInsCooperationProductOfflineBatchqueryModel : AopObject
    {
        /// <summary>
        /// 机构在蚂蚁平台上的惟一标识
        /// </summary>
        [XmlElement("inst_id")]
        public string InstId { get; set; }
    }
}
