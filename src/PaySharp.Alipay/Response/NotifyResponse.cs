using PaySharp.Core;
using PaySharp.Core.Response;
using System;

namespace PaySharp.Alipay.Response
{
    public class NotifyResponse : IResponse
    {
        /// <summary>
        /// 通知时间
        /// </summary>
        public DateTime NotifyTime { get; set; }

        /// <summary>
        /// 通知类型
        /// </summary>
        public string NotifyType { get; set; }

        /// <summary>
        /// 通知校验ID
        /// </summary>
        public string NotifyId { get; set; }

        /// <summary>
        /// 开发者的app_id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 编码格式
        /// </summary>
        public string Charset { get; set; }

        /// <summary>
        /// 接口版本
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 签名类型
        /// </summary>
        public string SignType { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// 授权方的app_id
        /// </summary>
        public string AuthAppId { get; set; }

        /// <summary>
        /// 支付宝交易号
        /// </summary>
        public string TradeNo { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 商户业务号
        /// </summary>
        public string OutBizNo { get; set; }

        /// <summary>
        /// 买家支付宝用户号
        /// </summary>
        public string BuyerId { get; set; }

        /// <summary>
        /// 买家支付宝账号
        /// </summary>
        public string BuyerLogonId { get; set; }

        /// <summary>
        /// 卖家支付宝用户号
        /// </summary>
        public string SellerId { get; set; }

        /// <summary>
        /// 卖家支付宝账号
        /// </summary>
        public string SellerEmail { get; set; }

        /// <summary>
        /// 交易状态
        /// </summary>
        public string TradeStatus { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public double TotalAmount { get; set; }

        /// <summary>
        /// 实收金额
        /// </summary>
        public double ReceiptAmount { get; set; }

        /// <summary>
        /// 开票金额
        /// </summary>
        public double InvoiceAmount { get; set; }

        /// <summary>
        /// 付款金额
        /// </summary>
        public double BuyerPayAmount { get; set; }

        /// <summary>
        /// 集分宝金额
        /// </summary>
        public double PointAmount { get; set; }

        /// <summary>
        /// 总退款金额
        /// </summary>
        [ReName(Name = "refund_fee")]
        public double RefundAmount { get; set; }

        /// <summary>
        /// 实际退款金额
        /// </summary>
        [ReName(Name = "send_back_fee")]
        public double SendBackAmount { get; set; }

        /// <summary>
        /// 订单标题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 交易创建时间
        /// </summary>
        public DateTime GmtCreate { get; set; }

        /// <summary>
        /// 交易付款时间
        /// </summary>
        public DateTime GmtPayment { get; set; }

        /// <summary>
        /// 交易退款时间
        /// </summary>
        public DateTime GmtRefund { get; set; }

        /// <summary>
        /// 交易结束时间
        /// </summary>
        public DateTime GmtClose { get; set; }

        /// <summary>
        /// 支付金额信息
        /// </summary>
        public string FundBillList { get; set; }

        /// <summary>
        /// 回传参数
        /// </summary>
        public string PassbackParams { get; set; }

        /// <summary>
        /// 优惠券信息
        /// </summary>
        public string VoucherDetailList { get; set; }

        public string Raw { get; set; }
    }
}
