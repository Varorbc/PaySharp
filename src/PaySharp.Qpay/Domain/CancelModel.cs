using System.ComponentModel.DataAnnotations;
using PaySharp.Core.Utils;

namespace PaySharp.Qpay.Domain
{
    public class CancelModel
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        [Required(ErrorMessage = "请设置商户订单号")]
        [StringLength(32, ErrorMessage = "商户订单号最大长度为32位")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 操作员ID
        /// </summary>
        [Required(ErrorMessage = "请设置操作员ID")]
        [StringLength(32, ErrorMessage = "操作员ID最大长度为32位")]
        public string OpUserId { get; set; } = "111111";

        /// <summary>
        /// 操作员密码
        /// </summary>
        [Required(ErrorMessage = "请设置操作员密码")]
        [StringLength(32, ErrorMessage = "退款原因最大长度为32位")]
        public string OpUserPasswd
        {
            get => _opUserPasswd;
            set => _opUserPasswd = EncryptUtil.MD5(value).ToLower();
        }
        private string _opUserPasswd = "111111";

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; } = Util.GenerateNonceStr();
    }
}
