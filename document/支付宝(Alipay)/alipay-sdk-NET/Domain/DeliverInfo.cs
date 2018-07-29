using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// DeliverInfo Data Structure.
    /// </summary>
    [Serializable]
    public class DeliverInfo : AopObject
    {
        /// <summary>
        /// 保单寄送地址的住址
        /// </summary>
        [XmlElement("recipients_address")]
        public string RecipientsAddress { get; set; }

        /// <summary>
        /// 配送地址行政区划代码
        /// </summary>
        [XmlElement("recipients_address_code")]
        public string RecipientsAddressCode { get; set; }

        /// <summary>
        /// 收件人姓名
        /// </summary>
        [XmlElement("recipients_name")]
        public string RecipientsName { get; set; }

        /// <summary>
        /// 收件人电话
        /// </summary>
        [XmlElement("recipients_phone")]
        public string RecipientsPhone { get; set; }
    }
}
