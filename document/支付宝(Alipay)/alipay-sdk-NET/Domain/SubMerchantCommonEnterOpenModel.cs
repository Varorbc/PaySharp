using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// SubMerchantCommonEnterOpenModel Data Structure.
    /// </summary>
    [Serializable]
    public class SubMerchantCommonEnterOpenModel : AopObject
    {
        /// <summary>
        /// 商户门店入驻的产品码,QRCODE_MERCHANT_OPEN:企业自建-扫码开票，INVOICE_RETURN:企业自建-发票回传，INVOICE_EXPENSE:发票报销。
        /// </summary>
        [XmlElement("product_code")]
        public string ProductCode { get; set; }

        /// <summary>
        /// 商户门店所属的服务方简称。
        /// </summary>
        [XmlElement("s_short_name")]
        public string SShortName { get; set; }
    }
}
