using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiMerchantOperatorFreezeModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiMerchantOperatorFreezeModel : AopObject
    {
        /// <summary>
        /// 操作码
        /// </summary>
        [XmlElement("auth_code")]
        public string AuthCode { get; set; }

        /// <summary>
        /// 操作员ID
        /// </summary>
        [XmlElement("operator_id")]
        public string OperatorId { get; set; }
    }
}
