using ICanPay.Core.Utils;
using System.ComponentModel.DataAnnotations;

namespace ICanPay.Wechatpay.Domain
{
    public class CloseModel
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        [Required(ErrorMessage = "请设置商户订单号")]
        [StringLength(32, ErrorMessage = "商户订单号最大长度为32位")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 随机字符串，长度要求在32位以内
        /// </summary>
        public string NonceStr { get; set; } = Util.GenerateNonceStr();
    }
}
