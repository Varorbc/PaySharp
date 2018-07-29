using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// MemberShip Data Structure.
    /// </summary>
    [Serializable]
    public class MemberShip : AopObject
    {
        /// <summary>
        /// 银行卡号
        /// </summary>
        [XmlElement("bank_card_no")]
        public string BankCardNo { get; set; }

        /// <summary>
        /// 会员二代身份证号码
        /// </summary>
        [XmlElement("cert_no")]
        public string CertNo { get; set; }

        /// <summary>
        /// 邮箱号码
        /// </summary>
        [XmlElement("email")]
        public string Email { get; set; }

        /// <summary>
        /// MAC地址
        /// </summary>
        [XmlElement("mac")]
        public string Mac { get; set; }

        /// <summary>
        /// 11位手机号码
        /// </summary>
        [XmlElement("mobile_phone_no")]
        public string MobilePhoneNo { get; set; }
    }
}
