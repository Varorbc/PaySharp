using PaySharp.Core;
using PaySharp.Core.Request;
using System;

namespace PaySharp.Wechatpay.Response
{
    public class TransferQueryResponse : BaseResponse
    {
        /// <summary>
        /// 微信企业付款单号
        /// </summary>
        [ReName(Name = "detail_id")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [ReName(Name = "partner_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 转账状态	：
        /// PROCESSING（处理中，如有明确失败，则返回额外失败原因；否则没有错误原因）
        /// SUCCESS（付款成功）
        /// FAILED（付款失败,需要替换付款单号重新发起付款）
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 用户标识，此参数为微信用户在商户对应appid下的唯一标识。
        /// </summary>
        [ReName(Name = "openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 收款用户姓名
        /// </summary>
        [ReName(Name = "transfer_name")]
        public string TrueName { get; set; }

        /// <summary>
        /// 付款金额
        /// </summary>
        [ReName(Name = "payment_amount")]
        public int Amount { get; set; }

        /// <summary>
        /// 转账时间
        /// </summary>
        [ReName(Name = "transfer_time")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 付款说明
        /// </summary>
        public string Desc { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
