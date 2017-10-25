using ICanPay.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICanPay.Alipay
{
    public class Notify : INotify
    {
        /// <summary>
        /// 通知时间
        /// </summary>
        [Display(Name = Constant.NOTIFY_TIME)]
        public DateTime NotifyTime { get; set; }

        /// <summary>
        /// 通知类型
        /// </summary>
        [Display(Name = Constant.NOTIFY_TYPE)]
        public string NotifyType { get; set; }

        /// <summary>
        /// 通知校验ID
        /// </summary>
        [Display(Name = Constant.NOTIFY_ID)]
        public string NotifyId { get; set; }

        /// <summary>
        /// 开发者的app_id
        /// </summary>
        [Display(Name = Constant.APP_ID)]
        public string AppId { get; set; }

        /// <summary>
        /// 编码格式
        /// </summary>
        [Display(Name = Constant.CHARSET)]
        public string Charset { get; set; }

        /// <summary>
        /// 接口版本
        /// </summary>
        [Display(Name = Constant.VERSION)]
        public string Version { get; set; }

        /// <summary>
        /// 签名类型
        /// </summary>
        [Display(Name = Constant.SIGN_TYPE)]
        public string SignType { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        [Display(Name = Constant.SIGN)]
        public string Sign { get; set; }

        /// <summary>
        /// 支付宝交易号
        /// </summary>
        [Display(Name = Constant.TRADE_NO)]
        public string Trade_no { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [Display(Name = Constant.OUT_TRADE_NO)]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 商户业务号
        /// </summary>
        [Display(Name = Constant.OUT_BIZ_NO)]
        public string OutBizNo { get; set; }

        /// <summary>
        /// 买家支付宝用户号
        /// </summary>
        [Display(Name = Constant.BUYER_ID)]
        public string BuyerId { get; set; }

        /// <summary>
        /// 买家支付宝账号
        /// </summary>
        [Display(Name = Constant.BUYER_LOGON_ID)]
        public string BuyerLogonId { get; set; }

        /// <summary>
        /// 卖家支付宝用户号
        /// </summary>
        [Display(Name = Constant.SELLER_ID)]
        public string SellerId { get; set; }

        /// <summary>
        /// 卖家支付宝账号
        /// </summary>
        [Display(Name = Constant.SELLER_EMAIL)]
        public string SellerEmail { get; set; }

        /// <summary>
        /// 交易状态
        /// </summary>
        [Display(Name = Constant.TRADE_STATUS)]
        public string TradeStatus { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        [Display(Name = Constant.TOTAL_AMOUNT)]
        public double TotalAmount { get; set; }

        /// <summary>
        /// 实收金额
        /// </summary>
        [Display(Name = Constant.RECEIPT_AMOUNT)]
        public double ReceiptAmount { get; set; }

        /// <summary>
        /// 开票金额
        /// </summary>
        [Display(Name = Constant.INVOICE_AMOUNT)]
        public double InvoiceAmount { get; set; }

        /// <summary>
        /// 付款金额
        /// </summary>
        [Display(Name = Constant.BUYER_PAY_AMOUNT)]
        public double BuyerPayAmount { get; set; }

        /// <summary>
        /// 集分宝金额
        /// </summary>
        [Display(Name = Constant.POINT_AMOUNT)]
        public double PointAmount { get; set; }

        /// <summary>
        /// 总退款金额
        /// </summary>
        [Display(Name = Constant.REFUND_FEE)]
        public double RefundFee { get; set; }

        /// <summary>
        /// 订单标题
        /// </summary>
        [Display(Name = Constant.SUBJECT)]
        public string Subject { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
        [Display(Name = Constant.BODY)]
        public string Body { get; set; }

        /// <summary>
        /// 交易创建时间
        /// </summary>
        [Display(Name = Constant.GMT_CREATE)]
        public DateTime GmtCreate { get; set; }

        /// <summary>
        /// 交易付款时间
        /// </summary>
        [Display(Name = Constant.GMT_PAYMENT)]
        public DateTime GmtPayment { get; set; }

        /// <summary>
        /// 交易退款时间
        /// </summary>
        [Display(Name = Constant.GMT_REFUND)]
        public DateTime GmtRefund { get; set; }

        /// <summary>
        /// 交易结束时间
        /// </summary>
        [Display(Name = Constant.GMT_CLOSE)]
        public DateTime GmtClose { get; set; }

        /// <summary>
        /// 支付金额信息
        /// </summary>
        [Display(Name = Constant.FUND_BILL_LIST)]
        public string FundBillList { get; set; }

        /// <summary>
        /// 回传参数
        /// </summary>
        [Display(Name = Constant.PASSBACK_PARAMS)]
        public string PassbackParams { get; set; }

        /// <summary>
        /// 优惠券信息
        /// </summary>
        [Display(Name = Constant.VOUCHER_DETAIL_LIST)]
        public string VoucherDetailList { get; set; }

        /// <summary>
        /// 网关返回码,详见文档
        /// https://docs.open.alipay.com/common/105806
        /// </summary>
        [Display(Name = Constant.CODE)]
        public string Code { get; set; }

        /// <summary>
        /// 网关返回码描述,详见文档
        /// https://docs.open.alipay.com/common/105806
        /// </summary>
        [Display(Name = Constant.MSG)]
        public string Message { get; set; }

        /// <summary>
        /// 网关返回码,详见文档
        /// https://docs.open.alipay.com/common/105806
        /// </summary>
        [Display(Name = Constant.SUBCODE)]
        public string SubCode { get; set; }

        /// <summary>
        /// 网关返回码描述,详见文档
        /// https://docs.open.alipay.com/common/105806
        /// </summary>
        [Display(Name = Constant.SUBMSG)]
        public string SubMessage { get; set; }

        /// <summary>
        /// 支付宝卡余额
        /// </summary>
        [Display(Name = Constant.CARD_BALANCE)]
        public string CardBalance { get; set; }

        /// <summary>
        /// 发生支付交易的商户门店名称
        /// </summary>
        [Display(Name = Constant.STORE_NAME)]
        public string StoreName { get; set; }

        /// <summary>
        /// 买家支付宝用户号
        /// </summary>
        [Display(Name = Constant.BUYER_USER_ID)]
        public string BuyerUserId { get; set; }

        /// <summary>
        /// 本交易支付时使用的所有优惠券信息
        /// </summary>
        [Display(Name = Constant.DISCOUNT_GOODS_DETAIL)]
        public string DiscountGoodsDetail { get; set; }

        /// <summary>
        /// 商户传入业务信息，具体值要和支付宝约定 
        /// 将商户传入信息分发给相应系统，应用于安全，营销等参数直传场景
        /// 格式为json格式
        /// </summary>
        [Display(Name = Constant.BUSINESS_PARAMS)]
        public string BusinessParams { get; set; }

        /// <summary>
        /// 当前预下单请求生成的二维码码串，可以用二维码生成工具根据该码串值生成对应的二维码
        /// </summary>
        [Display(Name = Constant.QR_CODE)]
        public string QrCode { get; set; }
    }
}
