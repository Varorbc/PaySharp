using System.ComponentModel.DataAnnotations;
using Org.BouncyCastle.Crypto;
using PaySharp.Core;

namespace PaySharp.Unionpay
{
    public class Merchant : IMerchant
    {
        /// <summary>
        /// 版本号
        /// </summary>
        public string Version => "5.1.0";

        /// <summary>
        /// 编码
        /// </summary>
        public string Encoding => "UTF-8";

        /// <summary>
        /// 证书号
        /// </summary>
        public string CertId { get; internal set; }

        /// <summary>
        /// 证书私钥
        /// </summary>
        [Ignore]
        internal AsymmetricKeyParameter CertKey { get; set; }

        /// <summary>
        /// 签名类型
        /// 01（表示采用 RSA 签名）
        /// </summary>
        [ReName(Name = "signMethod")]
        public string SignType => "01";

        /// <summary>
        /// 商户代码,即merId
        /// </summary>
        [ReName(Name = "merId")]
        [Required(ErrorMessage = "请设置商户代码")]
        [StringLength(15, ErrorMessage = "商户代码最大长度为15位")]
        public string AppId { get; set; }

        /// <summary>
        /// 后台返回商户结果时使用，
        /// 如上送，则发送商户后台交 易结果通知，不支持换行符等不可见字符，
        /// 如需通过专 线通知，需要在通知地址前面加上前缀：专线的首字母 加竖线 ZX|
        /// </summary>
        [ReName(Name = "backUrl")]
        [Required(ErrorMessage = "请设置通知地址")]
        [StringLength(256, ErrorMessage = "通知地址最大长度为256位")]
        public string NotifyUrl { get; set; }

        /// <summary>
        /// 前台返回商户结果时使用，前台类交易需上送 不支持换行符等不可见字符
        /// </summary>
        [ReName(Name = "frontUrl")]
        [StringLength(256, ErrorMessage = "前台成功返回地址最大长度为256位")]
        public string ReturnUrl { get; set; }

        /// <summary>
        /// 签名证书路径/base64字符串
        /// </summary>
        [Ignore]
        [Required(ErrorMessage = "请设置签名证书路径或base64字符串")]
        public string CertPath { get; set; }

        /// <summary>
        /// 签名证书密码
        /// </summary>
        [Ignore]
        [Required(ErrorMessage = "请设置签名证书密码")]
        public string CertPwd { get; set; }

        /// <summary>
        /// 接入类型	
        /// 0：商户直连接入
        /// 1：收单机构接入
        /// 2：平台商户接入
        /// </summary>
        [Required(ErrorMessage = "请设置接入类型")]
        public int AccessType { get; set; } = 0;
    }
}
