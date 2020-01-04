using System.ComponentModel.DataAnnotations;
using PaySharp.Core;

namespace PaySharp.Netpay
{
    public class Merchant : IMerchant
    {
        #region 属性

        /// <summary>
        /// 终端号
        /// </summary>
        [ReName(Name = "tid")]
        [Required(ErrorMessage = "请输入终端号")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "终端号最大长度为32位")]
        public string AppId { get; set; }

        /// <summary>
        /// 微信子AppId
        /// </summary>
        /// <remarks>只对微信支付有效</remarks>
        [StringLength(32, ErrorMessage = "微信子AppId最大长度为32位")]
        public string SubAppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        [ReName(Name = "mid")]
        [Required(ErrorMessage = "请设置商户号")]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "商户号最大长度为32位")]
        public string MchId { get; set; }

        /// <summary>
        /// 机构商户号
        /// </summary>
        [ReName(Name = "instMid")]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "机构商户号最大长度为32位")]
        public string InstMchId { get; set; }

        /// <summary>
        /// MD5交易密钥
        /// </summary>
        [Required(ErrorMessage = "请设置MD5交易密钥")]
        [Ignore]
        public string Key { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        [ReName(Name = "msgSrc")]
        [Required(ErrorMessage = "请设置来源")]
        public string Source { get; set; }

        /// <summary>
        /// 签名类型
        /// </summary>
        public string SignType => "MD5";

        /// <summary>
        /// 返回地址
        /// </summary>
        [ReName(Name = "showUrl")]
        public string ReturnUrl { get; set; }

        /// <summary>
        /// 网关回发通知URL
        /// </summary>
        [Required(ErrorMessage = "请输入网关回发通知URL")]
        public string NotifyUrl { get; set; }

        #endregion
    }
}
