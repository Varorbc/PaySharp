using PaySharp.Core;
using PaySharp.Core.Request;
using System;

namespace PaySharp.Wechatpay.Response
{
    public class TransferToBankQueryResponse : BaseResponse
    {
        /// <summary>
        /// 微信企业付款单号
        /// </summary>
        [ReName(Name = "payment_no")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [ReName(Name = "partner_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 收款用户银行卡号(MD5加密)	
        /// </summary>
        [ReName(Name = "bank_no_md5")]
        public string BankNo { get; set; }

        /// <summary>
        /// 收款人真实姓名(MD5加密)
        /// </summary>
        [ReName(Name = "true_name_md5")]
        public string TrueName { get; set; }

        /// <summary>
        /// 付款金额
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 代付订单状态：
        /// PROCESSING（处理中，如有明确失败，则返回额外失败原因；否则没有错误原因）
        /// SUCCESS（付款成功）
        /// FAILED（付款失败,需要替换付款单号重新发起付款）
        /// BANK_FAIL（银行退票，订单状态由付款成功流转至退票,退票时付款金额和手续费会自动退还）
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 手续费金额
        /// </summary>
        [ReName(Name = "cmms_amt")]
        public int Poundage { get; set; }

        /// <summary>
        /// 微信侧订单创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 微信侧付款成功时间（但无法保证银行不会退票）
        /// </summary>
        public DateTime PaySuccTime { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        public string Reason { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
