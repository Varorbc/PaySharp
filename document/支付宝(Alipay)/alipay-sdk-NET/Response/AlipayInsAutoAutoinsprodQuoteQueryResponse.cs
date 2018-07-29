using System;
using System.Xml.Serialization;
using Aop.Api.Domain;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayInsAutoAutoinsprodQuoteQueryResponse.
    /// </summary>
    public class AlipayInsAutoAutoinsprodQuoteQueryResponse : AopResponse
    {
        /// <summary>
        /// 商业险保费
        /// </summary>
        [XmlElement("business_premium")]
        public string BusinessPremium { get; set; }

        /// <summary>
        /// 商业险产品信息
        /// </summary>
        [XmlElement("business_product")]
        public InsProduct BusinessProduct { get; set; }

        /// <summary>
        /// 车辆信息
        /// </summary>
        [XmlElement("car")]
        public Car Car { get; set; }

        /// <summary>
        /// 如果是图片验证码问题，返回验证码的base64流
        /// </summary>
        [XmlElement("check_code")]
        public string CheckCode { get; set; }

        /// <summary>
        /// 图片验证码标识
        /// </summary>
        [XmlElement("check_code_id")]
        public string CheckCodeId { get; set; }

        /// <summary>
        /// 0-不需要、1-江苏验证码、2-中保信验证码
        /// </summary>
        [XmlElement("check_code_type")]
        public string CheckCodeType { get; set; }

        /// <summary>
        /// 保险公司ID
        /// </summary>
        [XmlElement("com_id")]
        public string ComId { get; set; }

        /// <summary>
        /// 保险公司简称
        /// </summary>
        [XmlElement("com_name")]
        public string ComName { get; set; }

        /// <summary>
        /// 车险询价申请号
        /// </summary>
        [XmlElement("enquiry_biz_id")]
        public string EnquiryBizId { get; set; }

        /// <summary>
        /// 交强险保费
        /// </summary>
        [XmlElement("force_premium")]
        public string ForcePremium { get; set; }

        /// <summary>
        /// 交强险产品信息
        /// </summary>
        [XmlElement("force_product")]
        public InsProduct ForceProduct { get; set; }

        /// <summary>
        /// 报价ID
        /// </summary>
        [XmlElement("quote_biz_id")]
        public string QuoteBizId { get; set; }

        /// <summary>
        /// 报价失败错误码，这个很重要
        /// </summary>
        [XmlElement("quote_error_code")]
        public string QuoteErrorCode { get; set; }

        /// <summary>
        /// 报价失败提示信息
        /// </summary>
        [XmlElement("quote_error_msg")]
        public string QuoteErrorMsg { get; set; }

        /// <summary>
        /// 实付保费[优惠后用户应付金额]
        /// </summary>
        [XmlElement("real_premium")]
        public string RealPremium { get; set; }

        /// <summary>
        /// 优惠保费
        /// </summary>
        [XmlElement("reduce_premium")]
        public string ReducePremium { get; set; }

        /// <summary>
        /// 总保费
        /// </summary>
        [XmlElement("total_premium")]
        public string TotalPremium { get; set; }
    }
}
