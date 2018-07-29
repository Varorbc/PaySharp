using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// MybankCreditSupplychainTradeCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class MybankCreditSupplychainTradeCreateModel : AopObject
    {
        /// <summary>
        /// 买家会员信息
        /// </summary>
        [XmlElement("buyer")]
        public Member Buyer { get; set; }

        /// <summary>
        /// 渠道，枚举如下：TMGXBL：天猫供销保理，TYZBL：通用自保理，TMZBL：天猫自保理，DSCYFRZ：大搜车预付融资
        /// </summary>
        [XmlElement("channel")]
        public string Channel { get; set; }

        /// <summary>
        /// 账款到期支付日期
        /// </summary>
        [XmlElement("expire_date")]
        public string ExpireDate { get; set; }

        /// <summary>
        /// 由具体业务决定填充内容，JSON格式
        /// </summary>
        [XmlElement("ext_data")]
        public string ExtData { get; set; }

        /// <summary>
        /// 外部订单号，格式：机构ipRoleId_外部订单号
        /// </summary>
        [XmlElement("out_order_no")]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 订单标题
        /// </summary>
        [XmlElement("out_order_title")]
        public string OutOrderTitle { get; set; }

        /// <summary>
        /// 买家付款账户信息
        /// </summary>
        [XmlElement("pay_account")]
        public Account PayAccount { get; set; }

        /// <summary>
        /// 卖家收款账户信息
        /// </summary>
        [XmlElement("rcv_account")]
        public Account RcvAccount { get; set; }

        /// <summary>
        /// 幂等编号，用于幂等控制，格式：机构ipRoleId_yyyymmddhhmmss_8位uniqId
        /// </summary>
        [XmlElement("request_id")]
        public string RequestId { get; set; }

        /// <summary>
        /// 销售产品码
        /// </summary>
        [XmlElement("sale_pd_code")]
        public string SalePdCode { get; set; }

        /// <summary>
        /// 卖家会员信息
        /// </summary>
        [XmlElement("seller")]
        public Member Seller { get; set; }

        /// <summary>
        /// 交易金额（单位：元），只支持两位小数点的正数
        /// </summary>
        [XmlElement("trade_amount")]
        public string TradeAmount { get; set; }

        /// <summary>
        /// FACTORING：保理，PREPAYMENT：预付融资，CREDITPAY：信任付
        /// </summary>
        [XmlElement("trade_type")]
        public string TradeType { get; set; }
    }
}
