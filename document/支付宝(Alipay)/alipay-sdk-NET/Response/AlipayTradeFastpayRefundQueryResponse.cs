using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayTradeFastpayRefundQueryResponse.
    /// </summary>
    public class AlipayTradeFastpayRefundQueryResponse : AopResponse
    {
        /// <summary>
        /// 行业特殊信息（例如在医保卡支付退款中，医保局向商户返回医疗信息）。
        /// </summary>
        [XmlElement("industry_sepc_detail")]
        public string IndustrySepcDetail { get; set; }

        /// <summary>
        /// 本笔退款对应的退款请求号
        /// </summary>
        [XmlElement("out_request_no")]
        public string OutRequestNo { get; set; }

        /// <summary>
        /// 创建交易传入的商户订单号
        /// </summary>
        [XmlElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 本次退款金额中买家退款金额
        /// </summary>
        [XmlElement("present_refund_buyer_amount")]
        public string PresentRefundBuyerAmount { get; set; }

        /// <summary>
        /// 本次退款金额中平台优惠退款金额
        /// </summary>
        [XmlElement("present_refund_discount_amount")]
        public string PresentRefundDiscountAmount { get; set; }

        /// <summary>
        /// 本次退款金额中商家优惠退款金额
        /// </summary>
        [XmlElement("present_refund_mdiscount_amount")]
        public string PresentRefundMdiscountAmount { get; set; }

        /// <summary>
        /// 本次退款请求，对应的退款金额
        /// </summary>
        [XmlElement("refund_amount")]
        public string RefundAmount { get; set; }

        /// <summary>
        /// 发起退款时，传入的退款原因
        /// </summary>
        [XmlElement("refund_reason")]
        public string RefundReason { get; set; }

        /// <summary>
        /// 该笔退款所对应的交易的订单金额
        /// </summary>
        [XmlElement("total_amount")]
        public string TotalAmount { get; set; }

        /// <summary>
        /// 支付宝交易号
        /// </summary>
        [XmlElement("trade_no")]
        public string TradeNo { get; set; }
    }
}
