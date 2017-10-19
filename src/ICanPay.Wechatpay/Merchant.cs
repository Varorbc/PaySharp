using ICanPay.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICanPay.Wechatpay
{
    public class Merchant : MerchantBase
    {

        #region 构造函数

        public Merchant()
        {
            SignType = "MD5";
        }

        #endregion

        #region 属性

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
        public string Key { get; set; }

        /// <summary>
        /// 公众帐号secert（仅JSAPI支付的时候需要配置）
        /// </summary>
        public string AppSecret { get; set; }

        /// <summary>
        /// 证书路径,注意应该填写绝对路径（仅退款、撤销订单时需要）
        /// </summary>
        public string SslCertPath { get; set; }

        /// <summary>
        /// 证书密码
        /// </summary>
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

        #endregion
    }
}
