using ICanPay.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICanPay.Alipay
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
        public string SignType => "RSA2";

        /// <summary>
        /// 格式
        /// </summary>
        public string Format = "JSON";

        /// <summary>
        /// 时间戳
        /// </summary>
        public string Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        /// <summary>
        /// 版本
        /// </summary>
        public string Version = "1.0";

        /// <summary>
        /// 编码格式
        /// </summary>
        public string Charset = "UTF-8";

        /// <summary>
        /// 接口名称
        /// </summary>
        public string Method { get; internal set; }

        /// <summary>
        /// 应用授权
        /// </summary>
        [StringLength(40, ErrorMessage = "应用授权最大长度为40位")]
        public string AppAuthToken { get; set; }

        /// <summary>
        /// 参数集合
        /// </summary>
        public string BizContent { get; internal set; }

        /// <summary>
        /// 商户私钥
        /// </summary>
        [Required(ErrorMessage = "请设置商户私钥")]
        public string Privatekey { get; set; }

        /// <summary>
        /// 支付宝公钥
        /// 查看地址：https://openhome.alipay.com/platform/keyManage.htm 对应APPID下的支付宝公钥
        /// </summary>
        [Required(ErrorMessage = "请设置支付宝公钥")]
        public string AlipayPublicKey { get; set; }

        private string returnUrl;
        /// <summary>
        /// 返回地址
        /// </summary>
        public string ReturnUrl
        {
            get
            {
                return returnUrl;
            }
            set
            {
                if (value.StartsWith("http") || value.StartsWith("https"))
                {
                    returnUrl = value;
                }
                else
                {
                    throw new FormatException("返回地址必须以http或https开头");
                }
            }
        }

        /// <summary>
        /// 网关回发通知URL
        /// </summary>
        [Necessary(new GatewayTradeType[] {
            GatewayTradeType.App,
            GatewayTradeType.Scan,
            GatewayTradeType.Wap,
            GatewayTradeType.Web }, ErrorMessage = "请输入网关回发通知URL")]
        public string NotifyUrl { get; set; }

        #endregion
    }
}
