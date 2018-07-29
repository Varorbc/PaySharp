using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayInsAutoAutoinsprodPolicyApplyModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayInsAutoAutoinsprodPolicyApplyModel : AopObject
    {
        /// <summary>
        /// 邮寄信息
        /// </summary>
        [XmlElement("deliver_info")]
        public DeliverInfo DeliverInfo { get; set; }

        /// <summary>
        /// 询价申请ID
        /// </summary>
        [XmlElement("enquiry_biz_id")]
        public string EnquiryBizId { get; set; }

        /// <summary>
        /// 指定保险公司支付宝收款账户,一般为保险公司收款账号登录ID
        /// </summary>
        [XmlElement("income_account_no")]
        public string IncomeAccountNo { get; set; }

        /// <summary>
        /// 报价ID
        /// </summary>
        [XmlElement("quote_biz_id")]
        public string QuoteBizId { get; set; }

        /// <summary>
        /// 付费方式,1-代理人付款，2-投保人付款
        /// </summary>
        [XmlElement("who_payed")]
        public string WhoPayed { get; set; }
    }
}
