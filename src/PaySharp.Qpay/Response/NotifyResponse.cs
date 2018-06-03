using PaySharp.Core;
using PaySharp.Core.Response;

namespace PaySharp.Qpay.Response
{
    public class NotifyResponse : IResponse
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        [ReName(Name = "appid")]
        public string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string MchId { get; set; }

        /// <summary>
        /// 设备号
        /// </summary>
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// 签名类型
        /// </summary>
        public string SignType { get; set; }

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
        /// 支付状态
        /// 固定值SUCCESS
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
        public double TotalAmount { get; set; }

        /// <summary>
        /// 货币类型
        /// 符合ISO 4217标准的三位字母代码，默认人民币：CNY，详见货币类型
        /// </summary>
        [ReName(Name = "fee_type")]
        public string AmountType { get; set; }

        /// <summary>
        /// 现金支付金额
        /// 订单现金支付金额，详见支付金额
        /// </summary>
        [ReName(Name = "cash_fee")]
        public double CashAmount { get; set; }

        /// <summary>
        /// QQ钱包优惠金额
        /// </summary>
        [ReName(Name = "coupon_fee")]
        public double CouponAmount { get; set; }

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

        public string Raw { get; set; }
    }
}
