using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// VcpAssetDetail Data Structure.
    /// </summary>
    [Serializable]
    public class VcpAssetDetail : AopObject
    {
        /// <summary>
        /// 资金金额
        /// </summary>
        [XmlElement("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// 资产金额
        /// </summary>
        [XmlElement("assetamount")]
        public string Assetamount { get; set; }

        /// <summary>
        /// 正常充值
        /// </summary>
        [XmlElement("assetusechannel")]
        public string Assetusechannel { get; set; }

        /// <summary>
        /// 收款用户id
        /// </summary>
        [XmlElement("settleuserid")]
        public string Settleuserid { get; set; }
    }
}
