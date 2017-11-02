using ICanPay.Core;
using System.ComponentModel.DataAnnotations;

namespace ICanPay.Wechatpay
{
    public class Merchant : IMerchant
    {

        #region 属性

        /// <summary>
        /// 应用ID
        /// </summary>
        [Required(ErrorMessage = "请输入支付机构提供的应用编号")]
        public string AppId { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }

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
        [NotAdd]
        public string Key { get; set; }

        /// <summary>
        /// 公众帐号secert（仅JSAPI支付的时候需要配置）
        /// </summary>
        [NotAdd]
        public string AppSecret { get; set; }

        /// <summary>
        /// 证书路径,注意应该填写绝对路径（仅退款、撤销订单时需要）
        /// </summary>
        [NotAdd]
        public string SslCertPath { get; set; }

        /// <summary>
        /// 证书密码
        /// </summary>
        [NotAdd]
        public string SslCertPassword { get; set; }

        /// <summary>
        /// 设备号
        /// 自定义参数，可以为终端设备号(门店号或收银设备ID)，PC网页或公众号内支付可以传"WEB"
        /// </summary>
        [StringLength(32, ErrorMessage = "设备号最大长度为32位")]
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 随机字符串，长度要求在32位以内
        /// </summary>
        public string NonceStr { get; set; }

        /// <summary>
        /// 网关回发通知URL
        /// </summary>
        [Required(ErrorMessage = "请输入网关回发通知URL")]
        public string NotifyUrl { get; set; }

        #endregion
    }
}
