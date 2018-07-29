using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// CardCreditInfo Data Structure.
    /// </summary>
    [Serializable]
    public class CardCreditInfo : AopObject
    {
        /// <summary>
        /// 是否允许超扣
        /// </summary>
        [XmlElement("allowoverpay")]
        public string Allowoverpay { get; set; }

        /// <summary>
        /// 超扣额度
        /// </summary>
        [XmlElement("creditquota")]
        public string Creditquota { get; set; }
    }
}
