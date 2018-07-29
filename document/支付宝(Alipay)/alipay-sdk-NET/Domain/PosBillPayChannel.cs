using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// PosBillPayChannel Data Structure.
    /// </summary>
    [Serializable]
    public class PosBillPayChannel : AopObject
    {
        /// <summary>
        /// 支付渠道类型
        /// </summary>
        [XmlElement("channel_type")]
        public string ChannelType { get; set; }

        /// <summary>
        /// 账单支付渠道维度优惠明细
        /// </summary>
        [XmlArray("discount_details")]
        [XmlArrayItem("pos_discount_detail")]
        public List<PosDiscountDetail> DiscountDetails { get; set; }

        /// <summary>
        /// 扩展信息，json对象格式，key和value都为字符串
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 收银员ID
        /// </summary>
        [XmlElement("operator")]
        public string Operator { get; set; }

        /// <summary>
        /// 外部支付订单号,唯一标识本次支付的requestID
        /// </summary>
        [XmlElement("out_pay_no")]
        public string OutPayNo { get; set; }

        /// <summary>
        /// 支付抵扣金额
        /// </summary>
        [XmlElement("pay_amount")]
        public string PayAmount { get; set; }

        /// <summary>
        /// 支付渠道本身自己的支付订单号
        /// </summary>
        [XmlElement("pay_no")]
        public string PayNo { get; set; }

        /// <summary>
        /// 付款时间
        /// </summary>
        [XmlElement("pay_time")]
        public string PayTime { get; set; }

        /// <summary>
        /// 支付实收金额
        /// </summary>
        [XmlElement("receipt_amount")]
        public string ReceiptAmount { get; set; }

        /// <summary>
        /// 用户身份标识：手机号码、userId等
        /// </summary>
        [XmlElement("user_identity")]
        public string UserIdentity { get; set; }
    }
}
