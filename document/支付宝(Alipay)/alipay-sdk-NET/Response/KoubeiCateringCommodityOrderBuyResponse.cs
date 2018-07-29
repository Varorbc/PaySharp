using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Response
{
    /// <summary>
    /// KoubeiCateringCommodityOrderBuyResponse.
    /// </summary>
    public class KoubeiCateringCommodityOrderBuyResponse : AopResponse
    {
        /// <summary>
        /// 扩展字段，供以后拓展使用
        /// </summary>
        [XmlArray("ext_info")]
        [XmlArrayItem("string")]
        public List<string> ExtInfo { get; set; }

        /// <summary>
        /// order_result为success时返回；order_result为fail的时候不返回
        /// </summary>
        [XmlElement("order_id")]
        public string OrderId { get; set; }

        /// <summary>
        /// success表示订购成功；fail表示订购失败
        /// </summary>
        [XmlElement("order_result")]
        public string OrderResult { get; set; }

        /// <summary>
        /// 描述订购结果信息
        /// </summary>
        [XmlElement("order_result_msg")]
        public string OrderResultMsg { get; set; }
    }
}
