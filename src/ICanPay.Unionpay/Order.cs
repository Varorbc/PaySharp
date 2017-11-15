using ICanPay.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICanPay.Unionpay
{
    public class Order : IOrder
    {
        /// <summary>
        /// 商户订单号，不应含“-”或“_”
        /// </summary>
        [Required]
        [ReName(Name = Constant.ORDERID)]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "商户订单号最小长度为8位,最大长度为40位")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 交易金额,单位元
        /// </summary>
        [Required]
        [ReName(Name = Constant.TXNAMT)]
        public double Amount
        {
            get => _amount;
            set => _amount = value * 100;
        }
        private double _amount;

        /// <summary>
        /// 银联不支持此字段，填写无效
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 交易币种,默认156
        /// </summary>
        public int CurrencyCode { get; set; } = 156;

        /// <summary>
        /// 订单发送时间
        /// </summary>
        public string TxnTime { get; internal set; } = DateTime.Now.ToString("yyyyMMddHHmmss");

        /// <summary>
        /// 订单接收超时时间,单位为毫秒，
        /// 交易发生时，该笔交易在银联全渠道系统中有效的最长时间。
        /// 当距离交易发送时间超过该时间时，银联全渠道系统不再为该笔交易提供支付服务
        /// </summary>
        public string OrderTimeout { get; set; }

        /// <summary>
        /// 支付超时时间,订单支付超时时间，超过此时间用户支付成功的交易，
        /// 不通知商户，系统自动退款，大约 5 个工作日金额返还 到用户账户
        /// </summary>
        public string PayTimeout { get; set; } = DateTime.Now.AddMinutes(15).ToString("yyyyMMddHHmmss");

        /// <summary>
        /// 发卡机构代码,当账号类型为 02-存折时需填写 在前台类交易时填写默认银行代码，支持直接跳转到网 银
        /// </summary>
        [StringLength(20, ErrorMessage = "发卡机构代码最大长度为1024位")]
        public string IssInsCode { get; set; }

        /// <summary>
        /// 商户自定义保留域，交易应答时会原样返回
        /// </summary>
        [StringLength(1024, ErrorMessage = "商户自定义保留域最大长度为1024位")]
        public string ReqReserved { get; set; }
    }
}
