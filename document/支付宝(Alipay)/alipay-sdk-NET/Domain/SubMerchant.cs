using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// SubMerchant Data Structure.
    /// </summary>
    [Serializable]
    public class SubMerchant : AopObject
    {
        /// <summary>
        /// 间连受理商户的支付宝商户编号，通过间连商户入驻后得到。间连业务下必传，并且需要按规范传递受理商户编号。
        /// </summary>
        [XmlElement("merchant_id")]
        public string MerchantId { get; set; }

        /// <summary>
        /// 商户id类型，
        /// </summary>
        [XmlElement("merchant_type")]
        public string MerchantType { get; set; }
    }
}
