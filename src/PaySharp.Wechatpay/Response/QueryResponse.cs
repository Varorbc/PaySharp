using PaySharp.Core;
using PaySharp.Core.Request;
using System.Collections.Generic;

namespace PaySharp.Wechatpay.Response
{
    public class QueryResponse : BaseResponse
    {
        /// <summary>
        /// 用户标识
        /// 用户在商户appid 下的唯一标识
        /// </summary>
        [ReName(Name = "openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 是否关注公众账号
        /// 仅在公众账号类型支付有效，取值范围：Y或N;Y-关注;N-未关注
        /// </summary>
        public string IsSubscribe { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        public string TradeType { get; set; }

        /// <summary>
        /// 交易状态
        /// SUCCESS—支付成功
        /// REFUND—转入退款
        /// NOTPAY—未支付
        /// CLOSED—已关闭
        /// REVOKED—已撤销（刷卡支付）
        /// USERPAYING--用户支付中
        /// PAYERROR--支付失败(其他原因，如银行返回失败)
        /// 支付状态机请见下单API页面
        /// </summary>
        public string TradeState { get; set; }

        /// <summary>
        /// 银行类型，采用字符串类型的银行标识，详见银行类型
        /// </summary>
        public string BankType { get; set; }

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
        /// 现金支付货币类型
        /// 符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [ReName(Name = "cash_fee_type")]
        public string CashAmountType { get; set; }

        /// <summary>
        /// 现金支付金额
        /// 订单现金支付金额，详见支付金额
        /// </summary>
        [ReName(Name = "cash_fee")]
        public int CashAmount { get; set; }

        /// <summary>
        /// 代金券金额
        /// “代金券”金额小于等于订单金额，订单金额-“代金券”金额=现金支付金额，详见支付金额
        /// </summary>
        [ReName(Name = "coupon_fee")]
        public int CouponAmount { get; set; }

        /// <summary>
        /// 代金券使用数量
        /// </summary>
        public int CouponCount { get; set; }

        /// <summary>
        /// 微信支付订单号
        /// </summary>
        [ReName(Name = "transaction_id")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 商家数据包
        /// </summary>
        public string Attach { get; set; }

        /// <summary>
        /// 支付完成时间
        /// </summary>
        public string TimeEnd { get; set; }

        /// <summary>
        /// 交易状态描述
        /// 对当前查询订单状态的描述和下一步操作的指引
        /// </summary>
        public string TradeStateDesc { get; set; }

        /// <summary>
        /// 退款代金券
        /// </summary>
        public List<CouponResponse> Coupons { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
            Coupons = ConvertUtil.ToList<CouponResponse, object>(GatewayData, -1);
        }

        public class CouponResponse
        {
            /// <summary>
            /// 编号
            /// </summary>
            [ReName(Name = "coupon_id")]
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
            [ReName(Name = "coupon_fee")]
            public int Amount { get; set; }
        }
    }
}
