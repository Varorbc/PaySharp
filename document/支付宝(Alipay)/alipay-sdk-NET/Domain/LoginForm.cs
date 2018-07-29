using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// LoginForm Data Structure.
    /// </summary>
    [Serializable]
    public class LoginForm : AopObject
    {
        /// <summary>
        /// 图片验证码
        /// </summary>
        [XmlElement("captcha")]
        public string Captcha { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [XmlElement("id_card_no")]
        public string IdCardNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [XmlElement("phone_no")]
        public string PhoneNo { get; set; }

        /// <summary>
        /// 查询密码
        /// </summary>
        [XmlElement("query_password")]
        public string QueryPassword { get; set; }

        /// <summary>
        /// 服务密码
        /// </summary>
        [XmlElement("service_password")]
        public string ServicePassword { get; set; }

        /// <summary>
        /// 短信验证码
        /// </summary>
        [XmlElement("sms_code")]
        public string SmsCode { get; set; }

        /// <summary>
        /// 吉林电信短信验证码
        /// </summary>
        [XmlElement("sms_code_jldx")]
        public string SmsCodeJldx { get; set; }
    }
}
