using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenPublicUserDataBatchqueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenPublicUserDataBatchqueryModel : AopObject
    {
        /// <summary>
        /// 开始日期
        /// </summary>
        [XmlElement("begin_date")]
        public string BeginDate { get; set; }

        /// <summary>
        /// 结束日期，开始日期/结束日期时间跨度最大30天
        /// </summary>
        [XmlElement("end_date")]
        public string EndDate { get; set; }
    }
}
