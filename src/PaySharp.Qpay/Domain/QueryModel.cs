using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PaySharp.Core;
using PaySharp.Core.Utils;

namespace PaySharp.Qpay.Domain
{
    public class QueryModel : IValidatableObject
    {
        /// <summary>
        /// 订单支付时传入的商户订单号,和QQ钱包订单号不能同时为空。 
        /// TradeNo,OutTradeNo如果同时存在优先取TradeNo
        /// </summary>
        [StringLength(32, ErrorMessage = "商户订单号最大长度为32位")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// QQ钱包订单号，和商户订单号不能同时为空
        /// </summary>
        [ReName(Name = "transaction_id")]
        [StringLength(32, ErrorMessage = "QQ钱包订单号最大长度为32位")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; } = Util.GenerateNonceStr();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(OutTradeNo) && string.IsNullOrEmpty(TradeNo))
            {
                yield return new ValidationResult("商户订单号和QQ钱包订单号不能同时为空");
            }

            yield return ValidationResult.Success;
        }
    }
}
