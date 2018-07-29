using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayCommerceTransportOfflinepayVirtualcardBatchqueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayCommerceTransportOfflinepayVirtualcardBatchqueryModel : AopObject
    {
        /// <summary>
        /// 卡号。和卡类型一起，唯一确定一张卡。为空时将返回该用户该卡类型下的所有卡。
        /// </summary>
        [XmlElement("card_no")]
        public string CardNo { get; set; }

        /// <summary>
        /// 卡类型。每种虚拟卡都有对应的卡类型，该值由支付宝分配给商户。
        /// </summary>
        [XmlElement("card_type")]
        public string CardType { get; set; }

        /// <summary>
        /// 蚂蚁统一会员ID
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
