using PaySharp.Core;
using PaySharp.Core.Request;
using System;
using System.Collections.Generic;
using static PaySharp.Wechatpay.Response.RefundResponse;

namespace PaySharp.Wechatpay.Response
{
    public class RefundQueryResponse : BaseResponse
    {
        /// <summary>
        /// 订单总退款次数
        /// </summary>
        public int TotalRefundCount { get; set; }

        /// <summary>
        /// 微信订单号
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
        /// 应结订单金额
        /// 当订单使用了免充值型优惠券后返回该参数，应结订单金额=订单金额-免充值优惠券金额。
        /// </summary>
        [ReName(Name = "settlement_total_fee")]
        public int SettlementTotalAmount { get; set; }

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
        /// 退款笔数	
        /// </summary>
        public int RefundCount { get; set; }

        /// <summary>
        /// 退款列表
        /// </summary>
        public List<RefundResponse> Refunds { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
            Refunds = ConvertUtil.ToList<RefundResponse, RefundCouponResponse>(GatewayData, -1);
        }

        public class RefundResponse
        {
            /// <summary>
            /// 商户退款单号	
            /// </summary>
            public string OutRefundNo { get; set; }

            /// <summary>
            /// 微信退款单号	
            /// </summary>
            [ReName(Name = "refund_id")]
            public string RefundNo { get; set; }

            /// <summary>
            /// 退款渠道
            /// ORIGINAL—原路退款
            /// BALANCE—退回到余额
            /// OTHER_BALANCE—原账户异常退到其他余额账户
            /// OTHER_BANKCARD—原银行卡异常退到其他银行卡
            /// </summary>
            public string RefundChannel { get; set; }

            /// <summary>
            /// 退款金额,退款总金额,单位为分,可以做部分退款
            /// </summary>
            [ReName(Name = "refund_fee")]
            public int RefundAmount { get; set; }

            /// <summary>
            /// 应结退款金额,去掉非充值代金券退款金额后的退款金额，退款金额=申请退款金额-非充值代金券退款金额，退款金额<=申请退款金额
            /// </summary>
            [ReName(Name = "settlement_refund_fee")]
            public int SettlementRefundAmount { get; set; }

            /// <summary>
            /// 代金券退款总金额,代金券退款金额<=退款金额，退款金额-代金券或立减优惠退款金额为现金，说明详见代金券或立减优惠
            /// </summary>
            [ReName(Name = "coupon_refund_fee")]
            public int CouponRefundAmount { get; set; }

            /// <summary>
            /// 退款代金券使用数量
            /// </summary>
            public int CouponRefundCount { get; set; }

            /// <summary>
            /// 退款代金券
            /// </summary>
            public List<RefundCouponResponse> RefundCoupons { get; set; }

            /// <summary>
            /// 退款状态
            /// SUCCESS—退款成功
            /// REFUNDCLOSE—退款关闭
            /// PROCESSING—退款处理中
            /// CHANGE—退款异常，退款到银行发现用户的卡作废或者冻结了，导致原路退款银行卡失败，可前往商户平台（pay.weixin.qq.com）-交易中心，手动处理此笔退款。
            /// </summary>
            public string RefundStatus { get; set; }

            /// <summary>
            /// 退款资金来源
            /// REFUND_SOURCE_RECHARGE_FUNDS---可用余额退款/基本账户
            /// REFUND_SOURCE_UNSETTLED_FUNDS---未结算资金退款
            /// </summary>
            public string RefundAccount { get; set; }

            /// <summary>
            /// 退款入款账户
            /// 取当前退款单的退款入账方
            /// 1）退回银行卡：
            /// 2）退回支付用户零钱:
            /// 3）退还商户:
            /// 4）退回支付用户零钱通:
            /// </summary>
            public string RefundRecvAccount { get; set; }

            /// <summary>
            /// 退款成功时间
            /// </summary>
            public DateTime RefundSuccessTime { get; set; }
        }
    }
}
