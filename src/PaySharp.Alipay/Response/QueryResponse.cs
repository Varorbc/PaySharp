using PaySharp.Alipay.Domain;
using PaySharp.Core.Request;
using System;
using System.Collections.Generic;

namespace PaySharp.Alipay.Response
{
    public class QueryResponse : BaseResponse
    {
        /// <summary>
        /// 支付宝交易号
        /// </summary>
        public string TradeNo { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 买家支付宝账号
        /// </summary>
        public string BuyerLogonId { get; set; }

        /// <summary>
        /// 交易状态
        /// </summary>
        public string TradeStatus { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public double TotalAmount { get; set; }

        /// <summary>
        /// 标价币种
        /// </summary>
        public string TransCurrency { get; set; }

        /// <summary>
        /// 结算币种
        /// </summary>
        public string SettleCurrency { get; set; }

        /// <summary>
        /// 结算金额
        /// </summary>
        public double SettleAmount { get; set; }

        /// <summary>
        /// 支付币种
        /// </summary>
        public string PayCurrency { get; set; }

        /// <summary>
        /// 支付金额
        /// </summary>
        public double PayAmount { get; set; }

        /// <summary>
        /// 结算币种兑换标价币种汇率
        /// </summary>
        public double SettleTransRate { get; set; }

        /// <summary>
        /// 标价币种兑换支付币种汇率
        /// </summary>
        public double TransPayRate { get; set; }

        /// <summary>
        /// 付款金额
        /// </summary>
        public double BuyerPayAmount { get; set; }

        /// <summary>
        /// 集分宝金额
        /// </summary>
        public double PointAmount { get; set; }

        /// <summary>
        /// 开票金额
        /// </summary>
        public double InvoiceAmount { get; set; }

        /// <summary>
        /// 本次交易打款给卖家的时间
        /// </summary>
        public DateTime SendPayDate { get; set; }

        /// <summary>
        /// 实收金额
        /// </summary>
        public double ReceiptAmount { get; set; }

        /// <summary>
        /// 商户门店编号
        /// </summary>
        public string StoreId { get; set; }

        /// <summary>
        /// 商户机具终端编号
        /// </summary>
        public string TerminalId { get; set; }

        /// <summary>
        /// 交易支付使用的资金渠道
        /// </summary>
        public List<TradeFundBill> FundBillList { get; set; }

        /// <summary>
        /// 发生支付交易的商户门店名称
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// 买家支付宝用户号
        /// </summary>
        public string BuyerUserId { get; set; }

        /// <summary>
        /// 预授权支付模式，该参数仅在信用预授权支付场景下返回。信用预授权支付：CREDIT_PREAUTH_PAY
        /// </summary>
        public string AuthTradePayMode { get; set; }

        /// <summary>
        /// 买家用户类型
        /// CORPORATE:企业用户
        /// PRIVATE:个人用户
        /// </summary>
        public string BuyerUserType { get; set; }

        /// <summary>
        /// 商家优惠金额
        /// </summary>
        public double MdiscountAmount { get; set; }

        /// <summary>
        /// 平台优惠金额
        /// </summary>
        public double DiscountAmount { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
