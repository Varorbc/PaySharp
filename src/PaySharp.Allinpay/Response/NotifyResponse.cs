using PaySharp.Allinpay.Enum;
using PaySharp.Core;
using PaySharp.Core.Response;

namespace PaySharp.Allinpay.Response
{
    public class NotifyResponse : IResponse
    {
        /// <summary>
        /// 应用编号
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 交易单号
        /// </summary>
        [ReName(Name = "trxid")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 第三方交易号
        /// </summary>
        [ReName(Name = "outtrxid")]
        public string ThirdTradeNo { get; set; }

        /// <summary>
        /// 渠道平台交易单号
        /// </summary>
        [ReName(Name = "chnltrxid")]
        public string ChannelTradeNo { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        [ReName(Name = "trxcode")]
        public TradeType TradeType { get; set; }

        /// <summary>
        /// 结算金额
        /// </summary>
        [ReName(Name = "trxamt")]
        public int SettleAmount { get; set; }

        /// <summary>
        /// 结算日期
        /// </summary>
        [ReName(Name = "trxdate")]
        public string SettleDate { get; set; }

        /// <summary>
        /// 支付时间
        /// </summary>
        public string PayTime { get; set; }

        /// <summary>
        /// 交易状态
        /// </summary>
        [ReName(Name = "trxstatus")]
        public string TradeStatus { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        [ReName(Name = "cusid")]
        public string MchId { get; set; }

        /// <summary>
        /// 终端编号
        /// </summary>
        [ReName(Name = "termno")]
        public string TerminalId { get; set; }

        /// <summary>
        /// 终端批次号
        /// </summary>
        [ReName(Name = "termbatchid")]
        public string TerminaBatchId { get; set; }

        /// <summary>
        /// 终端流水号
        /// </summary>
        [ReName(Name = "termtraceno")]
        public string TerminaTraceId { get; set; }

        /// <summary>
        /// 终端授权号
        /// </summary>
        [ReName(Name = "termauthno")]
        public string TerminaAuthId { get; set; }

        /// <summary>
        /// 终端参考号
        /// </summary>
        [ReName(Name = "termrefnum")]
        public string TerminaReferenceId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [ReName(Name = "trxreserved")]
        public string Remark { get; set; }

        /// <summary>
        /// 原交易单号
        /// </summary>
        [ReName(Name = "srctrxid")]
        public string OriginTradeNo { get; set; }

        /// <summary>
        /// 商户交易单号
        /// </summary>
        [ReName(Name = "cusorderid")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 签名类型
        /// </summary>
        public string SignType { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// 交易账户
        /// </summary>
        [ReName(Name = "acct")]
        public string TradeAccount { get; set; }

        /// <summary>
        /// 手续费金额
        /// </summary>
        [ReName(Name = "fee")]
        public int Poundage { get; set; }

        /// <summary>
        /// 渠道子商户号
        /// </summary>
        [ReName(Name = "cmid")]
        public string ChannelMchId { get; set; }

        /// <summary>
        /// 渠道号
        /// </summary>
        [ReName(Name = "chnlid")]
        public string ChannelId { get; set; }

        public string Raw { get; set; }
    }
}
