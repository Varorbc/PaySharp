using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AccPayeeInfo Data Structure.
    /// </summary>
    [Serializable]
    public class AccPayeeInfo : AopObject
    {
        /// <summary>
        /// 收款方电子钱包账号。
        /// </summary>
        [XmlElement("payee_account")]
        public string PayeeAccount { get; set; }

        /// <summary>
        /// 收款方电子钱包持有者姓名。
        /// </summary>
        [XmlElement("payee_name")]
        public string PayeeName { get; set; }
    }
}
