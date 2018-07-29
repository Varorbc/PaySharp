using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// CertInfo Data Structure.
    /// </summary>
    [Serializable]
    public class CertInfo : AopObject
    {
        /// <summary>
        /// 代发时商家上传的收款方证件号码    biz_scene=LOCAL时忽略该参数。
        /// </summary>
        [XmlElement("cert_no")]
        public string CertNo { get; set; }

        /// <summary>
        /// 代发时商家上传的收款方证件类型。    biz_scene=LOCAL时忽略该参数。
        /// </summary>
        [XmlElement("cert_type")]
        public string CertType { get; set; }
    }
}
