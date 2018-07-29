using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ZhimaMerchantOrderCreditQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class ZhimaMerchantOrderCreditQueryModel : AopObject
    {
        /// <summary>
        /// 外部订单号,包含字母、数字、下划线，调用方需要保证订单号唯一
        /// </summary>
        [XmlElement("out_order_no")]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 芝麻订单号
        /// </summary>
        [XmlElement("zm_order_no")]
        public string ZmOrderNo { get; set; }
    }
}
