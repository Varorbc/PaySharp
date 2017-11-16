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
        /// 订单描述,仅APP支付有效
        /// </summary>
        [ReName(Name = Constant.ORDERDESC)]
        [StringLength(32, ErrorMessage = "订单描述最大长度为32位")]
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
        [StringLength(20, ErrorMessage = "发卡机构代码最大长度为20位")]
        public string IssInsCode { get; set; }

        /// <summary>
        /// 商户自定义保留域，交易应答时会原样返回
        /// </summary>
        [StringLength(1024, ErrorMessage = "商户自定义保留域最大长度为1024位")]
        public string ReqReserved { get; set; }

        /// <summary>
        /// 交易账号。请求时使用加密公钥对交易账号加密，并做 Base64 编码后上送；
        /// 应答时如需返回，则使用签名私钥 进行解密。 
        /// 前台交易可由银联页面采集，也可由商户上送并返显。
        /// 如需锁定返显卡号，应通过保留域（reserved）上送卡 号锁定标识。
        /// </summary>
        [StringLength(1024, ErrorMessage = "交易账号最大长度为1024位")]
        public string AccNo { get; set; }

        /// <summary>
        /// 银行卡验证信息及身份信息
        /// 该域需整体做 Base64 编码。 
        /// 所有子域需用“有子域包含，子域间以“含，符号链接。 
        /// 格式如下：{子域名 1=值&子域名 2=值&子域名 3=值} 
        /// 各子域取值见注 
        /// 1。 借记卡可上送姓名、手机号、证件类型、证件号码；
        /// 贷记卡可上送姓名、手机号、证件类型、证件号码、有效 期、CVN2。
        /// 前台交易可以由银联页面采集，无需商户上送，后台交 易必须由商户上送。 
        /// 前台交易支持商户上送并返显的要素包含手机号，姓 名，证件号。
        /// </summary>
        [StringLength(1024, ErrorMessage = "银行卡验证信息及身份信息最大长度为1024位")]
        public string CustomerInfo { get; set; }

        /// <summary>
        /// 分期付款信息域
        /// 相关子域见注 10。 格式如下：{子域名1=值&子域名2=值&子域名3=值}
        /// </summary>
        [StringLength(1024, ErrorMessage = "分期付款信息域最大长度为1024位")]
        public string InstalTransInfo { get; set; }

        /// <summary>
        /// 标记化支付信息域
        /// 格式如下：{子域名1=值&子域名2=值&子域名3=值}
        /// 示例： tokenPayData={token=6201002708161330&trId=12345678&tokenLevel=55&tokenBegin=20140816093022&tokenEnd=20150816093021&tokenType=01}
        /// </summary>
        [StringLength(1024, ErrorMessage = "标记化支付信息域最大长度为1024位")]
        public string TokenPayData { get; set; }

        /// <summary>
        /// /持卡人IP
        /// </summary>
        public string CustomerIp { get; set; }
    }
}
