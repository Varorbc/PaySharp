using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayMarketingVoucherStockCreateResponse.
    /// </summary>
    public class AlipayMarketingVoucherStockCreateResponse : AopResponse
    {
        /// <summary>
        /// 本次重复导入数量
        /// </summary>
        [XmlElement("duplicate_count")]
        public long DuplicateCount { get; set; }

        /// <summary>
        /// 本次导入失败数量
        /// </summary>
        [XmlElement("fail_count")]
        public long FailCount { get; set; }

        /// <summary>
        /// 库存ID, 用于后续追加和查询库存
        /// </summary>
        [XmlElement("stock_id")]
        public string StockId { get; set; }

        /// <summary>
        /// 本次导入成功数量
        /// </summary>
        [XmlElement("success_count")]
        public long SuccessCount { get; set; }
    }
}
