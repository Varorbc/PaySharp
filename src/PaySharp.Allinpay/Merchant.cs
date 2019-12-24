using System.ComponentModel.DataAnnotations;
using PaySharp.Core;

namespace PaySharp.Allinpay
{
    public class Merchant : IMerchant
    {
        #region 属性

        /// <summary>
        /// 应用编号
        /// </summary>
        [Required(ErrorMessage = "请输入支付机构提供的应用编号")]
        [StringLength(8, ErrorMessage = "应用编号最大长度为8位")]
        public string AppId { get; set; }

        /// <summary>
        /// 微信子AppId
        /// </summary>
        /// <remarks>只对微信支付有效</remarks>
        [ReName(Name = "sub_appid")]
        [Required(ErrorMessage = "请输入支付机构提供的应用编号")]
        [StringLength(8, ErrorMessage = "应用编号最大长度为8位")]
        public string SubAppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        [ReName(Name = "cusid")]
        [Required(ErrorMessage = "请设置商户号")]
        [StringLength(15, ErrorMessage = "商户号最大长度为15位")]
        public string MchId { get; set; }

        /// <summary>
        /// 接口版本号
        /// </summary>
        [StringLength(2, ErrorMessage = "接口版本号最大长度为2位")]
        public string Version { get; set; } = "11";

        /// <summary>
        /// MD5交易密钥
        /// </summary>
        [Required(ErrorMessage = "请设置MD5交易密钥")]
        [Ignore]
        public string Key { get; set; }

        /// <summary>
        /// 签名类型
        /// </summary>
        public string SignType => "MD5";

        /// <summary>
        /// 网关回发通知URL
        /// </summary>
        [ReName(Name = "notify_url")]
        [Required(ErrorMessage = "请输入网关回发通知URL")]
        public string NotifyUrl { get; set; }

        #endregion
    }
}
