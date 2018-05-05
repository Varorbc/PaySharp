using PaySharp.Core;
using PaySharp.Core.Response;
using System;
using System.Collections.Generic;
using static PaySharp.Wechatpay.Response.QueryResponse;

namespace PaySharp.Wechatpay.Response
{
    public class NotifyResponse : IResponse
    {
        /// <summary>
        /// 返回状态码
        /// </summary>
        public string ReturnCode { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string ReturnMsg { get; set; }

        /// <summary>
        /// 应用ID
        /// </summary>
        [ReName(Name = "appid")]
        public string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string MchId { get; set; }

        /// <summary>
        /// 设备号
        /// </summary>
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; set; }

        /// <summary>
        /// 加密信息
        /// </summary>
        public string ReqInfo { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// 签名类型
        /// </summary>
        public string SignType { get; set; }

        /// <summary>
        /// 业务结果
        /// </summary>
        public string ResultCode { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public string ErrCode { get; set; }

        /// <summary>
        /// 错误代码描述
        /// </summary>
        public string ErrCodeDes { get; set; }

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
        /// 银行类型，采用字符串类型的银行标识，详见银行类型
        /// </summary>
        public string BankType { get; set; }

        /// <summary>
        /// 订单金额
        /// 订单总金额，单位为分
        /// </summary>
        [ReName(Name = "total_fee")]
        public double TotalAmount { get; set; }

        /// <summary>
        /// 应结订单金额
        /// 当订单使用了免充值型优惠券后返回该参数，应结订单金额=订单金额-免充值优惠券金额。
        /// </summary>
        [ReName(Name = "settlement_total_fee")]
        public double SettlementTotalAmount { get; set; }

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
        public double CashAmount { get; set; }

        /// <summary>
        /// 现金支付货币类型
        /// 符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [ReName(Name = "cash_fee_type")]
        public string CashAmountType { get; set; }

        /// <summary>
        /// 代金券金额
        /// “代金券”金额小于等于订单金额，订单金额-“代金券”金额=现金支付金额，详见支付金额
        /// </summary>
        [ReName(Name = "coupon_fee")]
        public double CouponAmount { get; set; }

        /// <summary>
        /// 代金券使用数量
        /// </summary>
        public int CouponCount { get; set; }

        /// <summary>
        /// 代金券
        /// </summary>
        public List<CouponResponse> Coupons { get; set; }

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
        /// 商户退款单号
        /// </summary>
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 微信退款单号	
        /// </summary>
        [ReName(Name = "refund_id")]
        public string RefundNo { get; set; }

        /// <summary>
        /// 退款金额	
        /// </summary>
        [ReName(Name = "refund_fee")]
        public string RefundAmount { get; set; }

        /// <summary>
        /// 应结退款金额	
        /// </summary>
        [ReName(Name = "settlement_refund_fee")]
        public string SettlementRefundAmount { get; set; }

        /// <summary>
        /// 退款状态
        /// </summary>
        public string RefundStatus { get; set; }

        /// <summary>
        /// 退款成功时间
        /// </summary>
        public DateTime SuccessTime { get; set; }

        /// <summary>
        /// 退款入账账户
        /// </summary>
        public string RefundRecvAccout { get; set; }

        /// <summary>
        /// 退款资金来源
        /// </summary>
        public string RefundAccount { get; set; }

        /// <summary>
        /// 退款发起来源
        /// </summary>
        public string RefundRequestSource { get; set; }

        public string Raw { get; set; }
    }
}
