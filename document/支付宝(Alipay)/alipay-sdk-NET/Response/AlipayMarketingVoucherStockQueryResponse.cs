using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayMarketingVoucherStockQueryResponse.
    /// </summary>
    public class AlipayMarketingVoucherStockQueryResponse : AopResponse
    {
        /// <summary>
        /// 剩余可用库存数量
        /// </summary>
        [XmlElement("available_count")]
        public long AvailableCount { get; set; }

        /// <summary>
        /// 库存总量
        /// </summary>
        [XmlElement("total_count")]
        public long TotalCount { get; set; }
    }
}
