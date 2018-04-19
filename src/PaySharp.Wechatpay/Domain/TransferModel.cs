using PaySharp.Core;
using PaySharp.Core.Utils;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Wechatpay.Domain
{
    public class TransferModel : IValidatableObject
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        [ReName(Name = "partner_trade_no")]
        [Required(ErrorMessage = "请设置商户订单号")]
        [StringLength(32, ErrorMessage = "商户订单号最大长度为32位")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 用户标识，此参数为微信用户在商户对应appid下的唯一标识。
        /// </summary>
        [ReName(Name = "openid")]
        [Required(ErrorMessage = "请设置用户标识")]
        public string OpenId { get; set; }

        /// <summary>
        /// 校验用户姓名选项
        /// NO_CHECK：不校验真实姓名 
        /// FORCE_CHECK：强校验真实姓名
        /// </summary>
        [Required(ErrorMessage = "请设置校验用户姓名选项")]
        public string CheckName { get; set; }

        /// <summary>
        /// 收款用户真实姓名
        /// </summary>
        [ReName(Name = "re_user_name")]
        public string TrueName { get; set; }

        /// <summary>
        /// 付款金额：RMB分
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 付款说明
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 用户端或者服务端的IP
        /// </summary>
        [Required(ErrorMessage = "请设置用户IP")]
        [StringLength(16, ErrorMessage = "用户IP最大长度为16位")]
        public string SpbillCreateIp { get; set; } = HttpUtil.LocalIpAddress;

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; } = Util.GenerateNonceStr();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CheckName == "FORCE_CHECK" && string.IsNullOrEmpty(TrueName))
            {
                yield return new ValidationResult("请设置收款用户真实姓名");
            }

            yield return ValidationResult.Success;
        }
    }
}
