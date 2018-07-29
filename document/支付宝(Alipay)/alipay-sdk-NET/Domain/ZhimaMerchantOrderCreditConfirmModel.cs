using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ZhimaMerchantOrderCreditConfirmModel Data Structure.
    /// </summary>
    [Serializable]
    public class ZhimaMerchantOrderCreditConfirmModel : AopObject
    {
        /// <summary>
        /// 商户订单号，必需参数，用于确认芝麻订单，该参数必须与调用接口（zhima.merchant.order.credit.create）时传入的out_order_no一致
        /// </summary>
        [XmlElement("out_order_no")]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 芝麻订单号，必需参数，用于确认芝麻订单，通过调用接口（zhima.merchant.order.credit.create）后获取
        /// </summary>
        [XmlElement("zm_order_no")]
        public string ZmOrderNo { get; set; }
    }
}
