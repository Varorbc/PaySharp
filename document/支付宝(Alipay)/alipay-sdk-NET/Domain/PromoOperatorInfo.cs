using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// PromoOperatorInfo Data Structure.
    /// </summary>
    [Serializable]
    public class PromoOperatorInfo : AopObject
    {
        /// <summary>
        /// 操作人id
        /// </summary>
        [XmlElement("operator_id")]
        public string OperatorId { get; set; }

        /// <summary>
        /// 操作人类型。SALES：口碑内部小二；MER：商户；MER_OPERATOR：商户员工；PROVIDER：服务商；PROVIDER_STAFF：服务商员工；
        /// </summary>
        [XmlElement("operator_type")]
        public string OperatorType { get; set; }
    }
}
