using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// MybankMarketingCampaignPrizeListConsultModel Data Structure.
    /// </summary>
    [Serializable]
    public class MybankMarketingCampaignPrizeListConsultModel : AopObject
    {
        /// <summary>
        /// 支付宝UID，2088开头
        /// </summary>
        [XmlElement("alipay_user_id")]
        public string AlipayUserId { get; set; }

        /// <summary>
        /// 业务交易金额，单位元
        /// </summary>
        [XmlElement("biz_amt")]
        public string BizAmt { get; set; }

        /// <summary>
        /// 咨询上下文，JSON结构
        /// </summary>
        [XmlElement("biz_context")]
        public string BizContext { get; set; }

        /// <summary>
        /// 业务流水号，幂等控制，调用方生成
        /// </summary>
        [XmlElement("biz_id")]
        public string BizId { get; set; }

        /// <summary>
        /// 业务发起渠道
        /// </summary>
        [XmlElement("channel")]
        public string Channel { get; set; }

        /// <summary>
        /// 银行参与者id，是在网商银行创建会员后生成的id，网商银行会员的唯一标识
        /// </summary>
        [XmlElement("ip_id")]
        public string IpId { get; set; }

        /// <summary>
        /// 银行参与者角色id，是在网商银行创建会员后生成的角色id，网商银行会员角色的唯一标识
        /// </summary>
        [XmlElement("ip_role_id")]
        public string IpRoleId { get; set; }

        /// <summary>
        /// 业务产品码
        /// </summary>
        [XmlElement("product_code")]
        public string ProductCode { get; set; }

        /// <summary>
        /// 多种奖品类型批量咨询，英文逗号分隔
        /// </summary>
        [XmlElement("type_list")]
        public string TypeList { get; set; }
    }
}
