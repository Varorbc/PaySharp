using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// SsdataDataserviceRiskIpprofileQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class SsdataDataserviceRiskIpprofileQueryModel : AopObject
    {
        /// <summary>
        /// 身份证号码
        /// </summary>
        [XmlElement("cert_no")]
        public string CertNo { get; set; }

        /// <summary>
        /// 交易发生的城市
        /// </summary>
        [XmlElement("city")]
        public string City { get; set; }

        /// <summary>
        /// 交易发生的区
        /// </summary>
        [XmlElement("district")]
        public string District { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        [XmlElement("ip_address")]
        public string IpAddress { get; set; }

        /// <summary>
        /// 调用服务的商户id ，如果是第三方服务商，需要将其实际的商户id透传过来，如果是普通商户传入自己的appid即可
        /// </summary>
        [XmlElement("partner_id")]
        public string PartnerId { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [XmlElement("phone")]
        public string Phone { get; set; }
    }
}
