using PaySharp.Core;
using PaySharp.Core.Request;

namespace PaySharp.Unionpay.Response
{
    public class QueryResponse : BaseResponse
    {
        /// <summary>
        /// 查询交易为退货或者消费撤销时返回，表示原消费交易的商户订单号
        /// </summary>
        public string OrigOrderId { get; set; }

        /// <summary>
        /// 查询交易为退货或者消费撤销时返回，表示原消费交易的商户发送交易时间
        /// </summary>
        public string OrigTxnTime { get; set; }

        /// <summary>
        /// 查询流水号	
        /// </summary>
        public string QueryId { get; set; }

        /// <summary>
        /// 清算日期	（月月日日）
        /// </summary>
        public string SettleDate { get; set; }

        /// <summary>
        /// 清算币种
        /// </summary>
        public string SettleCurrencyCode { get; set; }

        /// <summary>
        /// 清算金额
        /// </summary>
        [ReName(Name = "settleAmt")]
        public string SettleAmount { get; set; }

        /// <summary>
        /// 兑换日期
        /// </summary>
        public string ExchangeDate { get; set; }

        /// <summary>
        /// 交易币种
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 交易金额
        /// </summary>
        [ReName(Name = "txnAmt")]
        public int TotalAmount { get; set; }

        /// <summary>
        /// 清算汇率
        /// </summary>
        public string ExchangeRate { get; set; }

        /// <summary>
        /// 支付方式
        /// 默认不返回此域，如需要返此域，需要提交申请，视商户配置返回，可在消费类交易中返回以下中的一种：
        /// 0001：认证支付 
        /// 0002：快捷支付 
        /// 0004：储值卡支付 
        /// 0005：IC卡支付 
        /// 0201：网银支付 
        /// 1001：牡丹畅通卡支付 
        /// 1002：中铁银通卡支付 
        /// 0401：信用卡支付——暂定 
        /// 0402：小额临时支付 
        /// 0403：认证支付 2.0 
        /// 0404：互联网订单手机支付 
        /// 9000：其他无卡支付(如手机客户端支付)
        /// </summary>
        public string PayType { get; set; }

        /// <summary>
        /// 交易账号。请求时使用加密公钥对交易账号加密，并做 Base64 编码后上送；
        /// 应答时如需返回，则使用签名私钥 进行解密。 
        /// 前台交易可由银联页面采集，也可由商户上送并返显。 
        /// 如需锁定返显卡号，应通过保留域（reserved）上送卡 号锁定标识。
        /// </summary>
        public string AccNo { get; set; }

        /// <summary>
        /// 支付卡类型	
        /// 消费交易，视商户配置返回。该域取值为： 
        /// 00：未知
        /// 01：借记账户
        /// 02：贷记账户 
        /// 03：准贷记账户 
        /// 04：借贷合一账户 
        /// 05：预付费账户 
        /// 06：半开放预付费账户
        /// </summary>
        public string PayCardType { get; set; }

        /// <summary>
        /// 支付卡名称
        /// </summary>
        public string PayCardIssueName { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
