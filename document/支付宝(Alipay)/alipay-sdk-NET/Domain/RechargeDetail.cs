using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// RechargeDetail Data Structure.
    /// </summary>
    [Serializable]
    public class RechargeDetail : AopObject
    {
        /// <summary>
        /// 真实资金，单位元
        /// </summary>
        [XmlElement("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// 面额，单位元
        /// </summary>
        [XmlElement("assetamount")]
        public string Assetamount { get; set; }

        /// <summary>
        /// 内部订单号
        /// </summary>
        [XmlElement("orderno")]
        public string Orderno { get; set; }

        /// <summary>
        /// 外部订单号
        /// </summary>
        [XmlElement("outorderno")]
        public string Outorderno { get; set; }
    }
}
