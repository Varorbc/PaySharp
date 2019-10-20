using System.Collections.Generic;
using PaySharp.Core;
using PaySharp.Core.Request;

namespace PaySharp.Qpay.Response
{
    public class RefundQueryResponse : BaseResponse
    {
        /// <summary>
        /// QQ钱包订单号
        /// </summary>
        [ReName(Name = "transaction_id")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 订单金额
        /// 订单总金额，单位为分
        /// </summary>
        [ReName(Name = "total_fee")]
        public int TotalAmount { get; set; }

        /// <summary>
        /// 货币类型
        /// 符合ISO 4217标准的三位字母代码，默认人民币：CNY，详见货币类型
        /// </summary>
        [ReName(Name = "fee_type")]
        public string AmountType { get; set; }

        /// <summary>
        /// 现金支付金额
        /// 订单现金支付金额，详见支付金额
        /// </summary>
        [ReName(Name = "cash_fee")]
        public int CashAmount { get; set; }

        /// <summary>
        /// 退款列表
        /// </summary>
        public List<RefundResponse> Refunds { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
            Refunds = ConvertUtil.ToList<RefundResponse, object>(GatewayData, -1);
        }

        public class RefundResponse
        {
            /// <summary>
            /// 商户退款单号	
            /// </summary>
            public string OutRefundNo { get; set; }

            /// <summary>
            /// QQ钱包退款单号	
            /// </summary>
            [ReName(Name = "refund_id")]
            public string RefundNo { get; set; }

            /// <summary>
            /// 退款渠道
            /// ORIGINAL—原路退款
            /// BALANCE—退回到余额
            /// </summary>
            public string RefundChannel { get; set; }

            /// <summary>
            /// 退款申请金额
            /// </summary>
            [ReName(Name = "refund_fee")]
            public int RefundAmount { get; set; }

            /// <summary>
            /// 退款申请金额中，优惠或者立减的金额
            /// </summary>
            [ReName(Name = "coupon_refund_fee")]
            public int CouponRefundAmount { get; set; }

            /// <summary>
            /// 退款申请中的现金金额
            /// </summary>
            [ReName(Name = "cash_refund_fee")]
            public int CashRefundAmount { get; set; }

            /// <summary>
            /// 退款状态
            /// SUCCESS—退款成功
            /// FAIL—退款失败
            /// PROCESSING—退款发起成功，正在处理中
            /// CHANGE—转入代发，退款到银行发现用户的卡作废或者冻结了，导致原路退款银行卡失败，资金回流到商户的现金帐号，需要商户人工干预，通过线下或者财付通转账的方式进行退款。 
            /// </summary>
            public string RefundStatus { get; set; }

            /// <summary>
            /// 退款入款账户
            /// 取当前退款单的退款入账方
            /// 1）退回银行卡：
            /// 2）退回支付用户零钱:
            /// </summary>
            public string RefundRecvAccount { get; set; }
        }
    }
}
