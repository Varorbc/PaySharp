using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// RefundInfo Data Structure.
    /// </summary>
    [Serializable]
    public class RefundInfo : AopObject
    {
        /// <summary>
        /// 退款金额
        /// </summary>
        [XmlElement("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// 商品单ID
        /// </summary>
        [XmlElement("item_order_no")]
        public string ItemOrderNo { get; set; }
    }
}
