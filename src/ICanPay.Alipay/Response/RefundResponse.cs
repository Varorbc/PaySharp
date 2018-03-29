using ICanPay.Alipay.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ICanPay.Alipay.Response
{
    public class RefundResponse : BaseResponse
    {
        /// <summary>
        /// 买家支付宝账号
        /// </summary>
        public string BuyerLogonId { get; set; }

        /// <summary>
        /// 本次退款是否发生了资金变化
        /// </summary>
        public string FundChange { get; set; }

        /// <summary>
        /// 退款总金额
        /// </summary>
        [JsonProperty(PropertyName = "refund_fee")]
        public double RefundAmount { get; set; }

        /// <summary>
        /// 退款币种信息
        /// </summary>
        public string RefundCurrency { get; set; }

        /// <summary>
        /// 退款支付时间
        /// </summary>
        public DateTime GmtRefundPay { get; set; }

        /// <summary>
        /// 退款使用的资金渠道
        /// </summary>
        [JsonProperty(PropertyName = "refund_detail_item_list")]
        public List<TradeFundBill> TradeFundBills { get; set; }

        /// <summary>
        /// 发生支付交易的商户门店名称
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// 买家支付宝用户号
        /// </summary>
        public string BuyerUserId { get; set; }

        /// <summary>
        /// 本次退款金额中买家退款金额
        /// </summary>
        [JsonProperty(PropertyName = "present_refund_buyer_amount")]
        public double RefundBuyerAmount { get; set; }

        /// <summary>
        /// 本次退款金额中平台优惠退款金额
        /// </summary>
        [JsonProperty(PropertyName = "present_refund_discount_amount")]
        public double RefundDiscountAmount { get; set; }

        /// <summary>
        /// 本次退款金额中商家优惠退款金额
        /// </summary>
        [JsonProperty(PropertyName = "present_refund_mdiscount_amount")]
        public double RefundMdiscountAmount { get; set; }
    }
}
