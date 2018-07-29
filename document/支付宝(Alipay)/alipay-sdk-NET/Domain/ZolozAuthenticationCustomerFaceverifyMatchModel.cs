using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ZolozAuthenticationCustomerFaceverifyMatchModel Data Structure.
    /// </summary>
    [Serializable]
    public class ZolozAuthenticationCustomerFaceverifyMatchModel : AopObject
    {
        /// <summary>
        /// 活体照片的二进制内容，然后做base64编码
        /// </summary>
        [XmlElement("auth_img")]
        public string AuthImg { get; set; }

        /// <summary>
        /// C0：手机端采集的人脸图片  C1：机具端采集的人脸图片
        /// </summary>
        [XmlElement("auth_img_channel")]
        public string AuthImgChannel { get; set; }

        /// <summary>
        /// 商户请求的唯一标志，该标识作为对账的关键信息，商户要保证其唯一性
        /// </summary>
        [XmlElement("biz_id")]
        public string BizId { get; set; }

        /// <summary>
        /// 证件名字  （若type=2，此为必填项）
        /// </summary>
        [XmlElement("cert_name")]
        public string CertName { get; set; }

        /// <summary>
        /// 证件号码  (若type=2，此为必填项)
        /// </summary>
        [XmlElement("cert_no")]
        public string CertNo { get; set; }

        /// <summary>
        /// 证件类型  (若type=2，此为必填项)
        /// </summary>
        [XmlElement("cert_type")]
        public string CertType { get; set; }

        /// <summary>
        /// 业务方使用的账户唯一标示（如果type=1，此为必填项）
        /// </summary>
        [XmlElement("merchant_uid")]
        public string MerchantUid { get; set; }

        /// <summary>
        /// 比对源照片的二进制内容，然后做base64编码  （如果type=1，此为必填项）
        /// </summary>
        [XmlElement("ref_img")]
        public string RefImg { get; set; }

        /// <summary>
        /// 验证类型：  1：用户自定义  2：实名
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }
    }
}
