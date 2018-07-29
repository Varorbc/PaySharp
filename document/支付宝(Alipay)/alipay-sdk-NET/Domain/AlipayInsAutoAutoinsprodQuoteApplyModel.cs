using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayInsAutoAutoinsprodQuoteApplyModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayInsAutoAutoinsprodQuoteApplyModel : AopObject
    {
        /// <summary>
        /// 商业险产品信息
        /// </summary>
        [XmlElement("business_product")]
        public InsProduct BusinessProduct { get; set; }

        /// <summary>
        /// 用户录入验证码,当需要图片验证码时必传
        /// </summary>
        [XmlElement("check_code")]
        public string CheckCode { get; set; }

        /// <summary>
        /// 验证码对应id 当需要图片验证码时必传
        /// </summary>
        [XmlElement("check_code_id")]
        public string CheckCodeId { get; set; }

        /// <summary>
        /// 验证类型 0-不需要、1-江苏验证码、2-中保信验证码
        /// </summary>
        [XmlElement("check_type")]
        public string CheckType { get; set; }

        /// <summary>
        /// 机构编码 当微调报价时必传，当需要图片验证码时必传
        /// </summary>
        [XmlElement("company_id")]
        public string CompanyId { get; set; }

        /// <summary>
        /// 车险询价申请号
        /// </summary>
        [XmlElement("enquiry_biz_id")]
        public string EnquiryBizId { get; set; }

        /// <summary>
        /// 交强险产品信息
        /// </summary>
        [XmlElement("force_product")]
        public InsProduct ForceProduct { get; set; }

        /// <summary>
        /// 报价类型 1-微调，0-套餐
        /// </summary>
        [XmlElement("quote_type")]
        public string QuoteType { get; set; }
    }
}
