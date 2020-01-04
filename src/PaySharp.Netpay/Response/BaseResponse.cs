using PaySharp.Core;
using PaySharp.Core.Request;
using PaySharp.Core.Response;

namespace PaySharp.Netpay.Response
{
    public abstract class BaseResponse : IResponse
    {
        /// <summary>
        /// 平台错误码
        /// </summary>
        public string ErrCode { get; set; }

        /// <summary>
        /// 平台错误信息
        /// </summary>
        public string ErrMsg { get; set; }

        /// <summary>
        /// 消息编号
        /// </summary>
        public string MsgId { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        [ReName(Name = "msgSrc")]
        public string Source { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public string MsgType { get; set; }

        /// <summary>
        /// 请求系统预留字段
        /// </summary>
        public string SrcReserve { get; set; }

        /// <summary>
        /// 报文响应时间
        /// </summary>
        public string ResponseTimestamp { get; set; }

        /// <summary>
        /// 商户名称
        /// </summary>
        [ReName(Name = "merName")]
        public string MchName { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        [ReName(Name = "mid")]
        public string MchId { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [ReName(Name = "merOrderId")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 终端号
        /// </summary>
        [ReName(Name = "tid")]
        public string AppId { get; set; }

        /// <summary>
        /// 平台流水号
        /// </summary>
        [ReName(Name = "seqId")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 清分ID，如果来源方传了bankRefId就等于bankRefId，否则等于seqId
        /// </summary>
        public string SettleRefId { get; set; }

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
        /// 支付总金额
        /// </summary>
        public int TotalAmount { get; set; }

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
        /// 渠道状态
        /// </summary>
        [ReName(Name = "targetStatus")]
        public string ChannelStatus { get; set; }

        /// <summary>
        /// 渠道商户号
        /// </summary>
        [ReName(Name = "targetMid")]
        public string ChannelMchId { get; set; }

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
        /// 原始值
        /// </summary>
        public string Raw { get; set; }

        internal GatewayData GatewayData { get; set; }

        internal abstract void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request) where TResponse : IResponse;
    }
}
