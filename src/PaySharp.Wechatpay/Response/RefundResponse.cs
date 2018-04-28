using PaySharp.Core;
using PaySharp.Core.Request;
using System.Collections.Generic;

namespace PaySharp.Wechatpay.Response
{
    public class RefundResponse : BaseResponse
    {
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
        /// 商户退款单号	
        /// </summary>
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 微信退款单号	
        /// </summary>
        [ReName(Name = "refund_id")]
        public string RefundNo { get; set; }

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
        /// 现金支付货币类型
        /// 符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [ReName(Name = "cash_fee_type")]
        public string CashAmountType { get; set; }

        /// <summary>
        /// 现金退款金额,现金退款金额，单位为分，只能为整数，详见支付金额
        /// </summary>
        [ReName(Name = "cash_refund_fee")]
        public int CashRefundAmount { get; set; }

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

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
            RefundCoupons = ConvertUtil.ToList<RefundCouponResponse, object>(GatewayData, -1);
        }

        public class RefundCouponResponse
        {
            /// <summary>
            /// 编号
            /// </summary>
            [ReName(Name = "coupon_refund_id")]
            public string Id { get; set; }

            /// <summary>
            /// 类型
            /// CASH--充值代金券
            /// NO_CASH---非充值优惠券
            /// </summary>
            [ReName(Name = "coupon_type")]
            public string Type { get; set; }

            /// <summary>
            /// 金额
            /// </summary>
            [ReName(Name = "coupon_refund_fee")]
            public int Amount { get; set; }
        }
    }
}
