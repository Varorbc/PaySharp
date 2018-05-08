using PaySharp.Core;
using PaySharp.Core.Request;

namespace PaySharp.Qpay.Response
{
    public class QueryResponse : BaseResponse
    {
        /// <summary>
        /// 设备号
        /// </summary>
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 用户标识
        /// 用户在商户appid 下的唯一标识
        /// </summary>
        [ReName(Name = "openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        public string TradeType { get; set; }

        /// <summary>
        /// 交易状态
        /// SUCCESS 支付成功
        /// REFUND 转入退款
        /// REVOKED订单已撤销
        /// CLOSED 订单已关闭
        /// USERPAYING 用户支付中
        /// </summary>
        public string TradeState { get; set; }

        /// <summary>
        /// 银行类型，采用字符串类型的银行标识，详见银行类型
        /// </summary>
        public string BankType { get; set; }

        /// <summary>
        /// 订单金额
        /// 订单总金额，单位为分
        /// </summary>
        [ReName(Name = "total_fee")]
        public int TotalAmount { get; set; }

        /// <summary>
        /// 货币类型
        /// 默认为人民币：CNY
        /// </summary>
        [ReName(Name = "fee_type")]
        public string AmountType { get; set; }

        /// <summary>
        /// 用户本次交易中，实际支付的金额
        /// </summary>
        [ReName(Name = "cash_fee")]
        public int CashAmount { get; set; }

        /// <summary>
        /// QQ钱包优惠金额
        /// </summary>
        [ReName(Name = "coupon_fee")]
        public int CouponAmount { get; set; }

        /// <summary>
        /// QQ钱包支付订单号
        /// </summary>
        [ReName(Name = "transaction_id")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 商家数据包
        /// </summary>
        public string Attach { get; set; }

        /// <summary>
        /// 支付完成时间
        /// </summary>
        public string TimeEnd { get; set; }

        /// <summary>
        /// 交易状态描述
        /// 对当前查询订单状态的描述和下一步操作的指引
        /// </summary>
        public string TradeStateDesc { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
