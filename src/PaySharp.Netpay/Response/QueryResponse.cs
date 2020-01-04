using System;
using PaySharp.Core;
using PaySharp.Core.Request;

namespace PaySharp.Netpay.Response
{
    public class QueryResponse : BaseResponse
    {
        /// <summary>
        /// 机构商户号
        /// </summary>
        [ReName(Name = "instMid")]
        public string InstMchId { get; set; }

        /// <summary>
        /// 检索参考号，用在银联体系交易中
        /// </summary>
        public string RefId { get; set; }

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
        /// 银行卡号
        /// </summary>
        public string BankCardNo { get; set; }

        /// <summary>
        /// 银行信息
        /// </summary>
        public string BankInfo { get; set; }

        /// <summary>
        /// 支付渠道列表
        /// </summary>
        public string BillFunds { get; set; }

        /// <summary>
        /// 支付渠道描述
        /// </summary>
        public string BillFundsDesc { get; set; }

        /// <summary>
        /// 优惠金额
        /// </summary>
        public int CouponAmount { get; set; }

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
        /// 支付时间
        /// </summary>
        public DateTime PayTime { get; set; }

        /// <summary>
        /// 结算日期
        /// </summary>
        public DateTime SettleDate { get; set; }

        /// <summary>
        /// 微信活动编号
        /// </summary>
        public string ActivityIds { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
