using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// SupplierVO Data Structure.
    /// </summary>
    [Serializable]
    public class SupplierVO : AopObject
    {
        /// <summary>
        /// 生效状态，EFFECTIVE：生效，INVALID：失效。
        /// </summary>
        [XmlElement("biz_status")]
        public string BizStatus { get; set; }

        /// <summary>
        /// 快餐
        /// </summary>
        [XmlElement("business_desc")]
        public string BusinessDesc { get; set; }

        /// <summary>
        /// 供应商附加信息，LICENSE_NO:许可证号,LICENSE_DATE:营业执照有效期,PAYMENT_DAYS:账期
        /// </summary>
        [XmlElement("certificate_desc")]
        public string CertificateDesc { get; set; }

        /// <summary>
        /// 供货商简码
        /// </summary>
        [XmlElement("short_code")]
        public string ShortCode { get; set; }

        /// <summary>
        /// 供货商ID
        /// </summary>
        [XmlElement("supplier_id")]
        public string SupplierId { get; set; }

        /// <summary>
        /// 张三
        /// </summary>
        [XmlElement("supplier_name")]
        public string SupplierName { get; set; }
    }
}
