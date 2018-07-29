using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayFundTransAuctionBalanceQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayFundTransAuctionBalanceQueryModel : AopObject
    {
        /// <summary>
        /// 业务id，唯一业务标识
        /// </summary>
        [XmlElement("biz_id")]
        public string BizId { get; set; }

        /// <summary>
        /// 开户银行标识
        /// </summary>
        [XmlElement("inst_id")]
        public string InstId { get; set; }

        /// <summary>
        /// 支付宝userId
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// 核身id，用于验证是否已经核身成功
        /// </summary>
        [XmlElement("verify_id")]
        public string VerifyId { get; set; }
    }
}
