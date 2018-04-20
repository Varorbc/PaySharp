using PaySharp.Core;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Wechatpay
{
    public class Merchant : IMerchant
    {
        #region 属性

        /// <summary>
        /// 应用ID
        /// </summary>
        [Required(ErrorMessage = "请输入支付机构提供的应用编号")]
        [ReName(Name = "appid")]
        public string AppId { get; set; }

        /// <summary>
        /// 签名类型
        /// </summary>
        public string SignType => "MD5";

        /// <summary>
        /// 商户号
        /// </summary>
        [Required(ErrorMessage = "请设置商户号")]
        [StringLength(32, ErrorMessage = "商户号最大长度为32位")]
        public string MchId { get; set; }

        /// <summary>
        /// 商户支付密钥，参考开户邮件设置
        /// </summary>
        [Required(ErrorMessage = "请设置商户支付密钥")]
        [Ignore]
        public string Key { get; set; }

        /// <summary>
        /// 应用Secret
        /// </summary>
        [Ignore]
        public string AppSecret { get; set; }

        /// <summary>
        /// 证书路径,注意应该填写绝对路径
        /// </summary>
        [Ignore]
        public string SslCertPath { get; set; }

        /// <summary>
        /// 证书密码
        /// </summary>
        [Ignore]
        public string SslCertPassword { get; set; }

        /// <summary>
        /// 网关回发通知URL
        /// </summary>
        [Required(ErrorMessage = "请输入网关回发通知URL")]
        public string NotifyUrl { get; set; }

        /// <summary>
        /// 商户公钥
        /// 通过PublicKeyRequest获取
        /// </summary>
        [Ignore]
        public string PublicKey { get; set; }

        #endregion
    }
}
