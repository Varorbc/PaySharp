using System;
using PaySharp.Core;
using PaySharp.Core.Response;

namespace PaySharp.Netpay.Response
{
    public class NotifyResponse : IResponse
    {
        /// <summary>
        /// 商户号
        /// </summary>
        [ReName(Name = "mid")]
        public string MchId { get; set; }

        /// <summary>
        /// 终端号
        /// </summary>
        [ReName(Name = "tid")]
        public string AppId { get; set; }

        /// <summary>
        /// 机构商户号
        /// </summary>
        [ReName(Name = "instMid")]
        public string InstMchId { get; set; }

        /// <summary>
        /// 商户附加数据
        /// </summary>
        public string AttachedData { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        public string BankCardNo { get; set; }

        /// <summary>
        /// 支付渠道列表
        /// </summary>
        public string BillFunds { get; set; }

        /// <summary>
        /// 支付渠道描述
        /// </summary>
        public string BillFundsDesc { get; set; }

        /// <summary>
        /// 买家编号
        /// </summary>
        public string BuyerId { get; set; }

        /// <summary>
        /// 子买家编号
        /// </summary>
        public string SubBuyerId { get; set; }

        /// <summary>
        /// 买家用户名
        /// </summary>
        public string BuyerUsername { get; set; }

        /// <summary>
        /// 买家付款的金额
        /// </summary>
        public int BuyerPayAmount { get; set; }

        /// <summary>
        /// 支付总金额
        /// </summary>
        public int TotalAmount { get; set; }

        /// <summary>
        /// 发票金额
        /// </summary>
        public int InvoiceAmount { get; set; }

        /// <summary>
        /// 实收金额
        /// </summary>
        public int ReceiptAmount { get; set; }

        /// <summary>
        /// 退款金额
        /// </summary>
        public int RefundAmount { get; set; }

        /// <summary>
        /// 退款说明
        /// </summary>
        public string RefundDesc { get; set; }

        /// <summary>
        /// 渠道退款号
        /// </summary>
        [ReName(Name = "refundTargetOrderId")]
        public string ChannelRefundNo { get; set; }

        /// <summary>
        /// 退款时间
        /// </summary>
        [ReName(Name = "refundPayTime")]
        public DateTime? RefundTime { get; set; }

        /// <summary>
        /// 退款结算日期
        /// </summary>
        [ReName(Name = "refundPayTime")]
        public DateTime? RefundSettleDate { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [ReName(Name = "merOrderId")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime PayTime { get; set; }

        /// <summary>
        /// 检索参考号，用在银联体系交易中
        /// </summary>
        public string RefId { get; set; }

        /// <summary>
        /// 平台流水号
        /// </summary>
        [ReName(Name = "seqId")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 结算日期
        /// </summary>
        public DateTime SettleDate { get; set; }

        /// <summary>
        /// 交易状态
        /// NEW_ORDER 新订单
        /// UNKNOWN 不明确的交易状态
        /// TRADE_CLOSED 在指定时间段内未支付时关闭的交易；在交易完成撤销成功时关闭的交易；支付失败的交易。
        /// WAIT_BUYER_PAY  交易创建，等待买家付款。
        /// TRADE_SUCCESS 支付成功
        /// TRADE_REFUND 订单转入退货流程
        /// </summary>
        [ReName(Name = "status")]
        public string TradeStatus { get; set; }

        /// <summary>
        /// 连接系统
        /// </summary>
        public string ConnectSys { get; set; }

        /// <summary>
        /// 渠道订单号
        /// </summary>
        [ReName(Name = "targetOrderId")]
        public string ChannelTradeNo { get; set; }

        /// <summary>
        /// 渠道代码
        /// Alipay 1.0 支付宝1.0协议
        /// Alipay 2.0 支付宝2.0协议
        /// WXPay 微信
        /// YQB 壹钱包
        /// QMF 全民付远程快捷
        /// UnionPay 银联钱包
        /// BaiDu 百度钱包
        /// JD 京东钱包
        /// SF 顺丰顺手付
        /// COMM 交通银行
        /// BestPay 翼支付
        /// ACP 银联全渠道立码付
        /// NetPayBills 银商网付平台账单模块
        /// NetPayGtwy 银商网付平台网关模块
        /// QmfWebPay POS通插件WEB版
        /// UAC 银联全渠道
        /// </summary>
        [ReName(Name = "targetSys")]
        public string ChannelCode { get; set; }

        /// <summary>
        /// 营销联盟优惠金额
        /// </summary>
        [ReName(Name = "yxlmAmount")]
        public int MarketingAffiliateAmount { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// 商户出资优惠金额
        /// </summary>
        public int CouponMerchantContribute { get; set; }

        /// <summary>
        /// 其他出资优惠金额
        /// </summary>
        public int CouponOtherContribute { get; set; }

        /// <summary>
        /// 微信活动编号
        /// </summary>
        public string ActivityIds { get; set; }

        /// <summary>
        /// 订单详情
        /// </summary>
        [ReName(Name = "orderDesc")]
        public string Body { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }

        /// <summary>
        /// 商户UUID
        /// </summary>
        [ReName(Name = "mchntUuid")]
        public string MchUuid { get; set; }

        /// <summary>
        /// 商户所属分支机构代码
        /// </summary>
        public string SubInst { get; set; }

        /// <summary>
        /// 退货外部订单号
        /// </summary>
        public string RefundExtOrderId { get; set; }

        /// <summary>
        /// 商品交易单号
        /// </summary>
        public string GoodsTradeNo { get; set; }

        /// <summary>
        /// 外部订单号
        /// </summary>
        public string ExtOrderId { get; set; }

        /// <summary>
        /// 担保交易状态
        /// </summary>
        public string SecureStatus { get; set; }

        /// <summary>
        /// 担保完成金额
        /// </summary>
        public string CompleteAmount { get; set; }

        public string Raw { get; set; }
    }
}
