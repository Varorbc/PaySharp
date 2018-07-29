using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// RiskResult Data Structure.
    /// </summary>
    [Serializable]
    public class RiskResult : AopObject
    {
        /// <summary>
        /// 风险类型，比如0表示广告
        /// </summary>
        [XmlElement("risk_type")]
        public string RiskType { get; set; }

        /// <summary>
        /// 风险识别分数，0-100，分值越大风险越高
        /// </summary>
        [XmlElement("score")]
        public string Score { get; set; }
    }
}
