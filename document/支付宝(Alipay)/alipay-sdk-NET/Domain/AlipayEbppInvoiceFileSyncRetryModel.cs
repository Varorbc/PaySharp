using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayEbppInvoiceFileSyncRetryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayEbppInvoiceFileSyncRetryModel : AopObject
    {
        /// <summary>
        /// 发票代码
        /// </summary>
        [XmlElement("einv_code")]
        public string EinvCode { get; set; }

        /// <summary>
        /// 发票号码
        /// </summary>
        [XmlElement("einv_no")]
        public string EinvNo { get; set; }

        /// <summary>
        /// 文件下载链接，在is_url_replace为true的时候，该字段必填
        /// </summary>
        [XmlElement("file_url")]
        public string FileUrl { get; set; }

        /// <summary>
        /// 是否需要替换文件下载链接
        /// </summary>
        [XmlElement("is_url_replace")]
        public bool IsUrlReplace { get; set; }

        /// <summary>
        /// 商户简称，userId未传的时候，该字段必填
        /// </summary>
        [XmlElement("m_short_name")]
        public string MShortName { get; set; }

        /// <summary>
        /// 外部交易流水号，userId未传的情况下，该字段必填
        /// </summary>
        [XmlElement("out_biz_no")]
        public string OutBizNo { get; set; }

        /// <summary>
        /// 蚂蚁统一会员ID，该字段未传的情况下，商户简称和外部交易流水号必填
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
