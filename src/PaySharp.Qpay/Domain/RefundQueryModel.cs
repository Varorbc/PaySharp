using PaySharp.Core;
using PaySharp.Core.Utils;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Qpay.Domain
{
    public class RefundQueryModel : IValidatableObject
    {
        /// <summary>
        /// 商户订单号
        /// QQ钱包订单号查询的优先级是： RefundNo > OutRefundNo > TradeNo > OutTradeNo
        /// </summary>
        [StringLength(32, ErrorMessage = "商户订单号最大长度为32位")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// QQ钱包订单号
        /// </summary>
        [ReName(Name = "transaction_id")]
        [StringLength(32, ErrorMessage = "QQ钱包订单号最大长度为32位")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 商户退款单号	
        /// </summary>
        [StringLength(32, ErrorMessage = "商户退款单号最大长度为32位")]
        public string OutRefundNo { get; set; }

        /// <summary>
        /// QQ钱包退款单号	
        /// </summary>
        [ReName(Name = "refund_id")]
        [StringLength(32, ErrorMessage = "QQ钱包退款单号最大长度为32位")]
        public string RefundNo { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; } = Util.GenerateNonceStr();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(OutTradeNo) && string.IsNullOrEmpty(TradeNo)
                && string.IsNullOrEmpty(OutRefundNo) && string.IsNullOrEmpty(RefundNo))
            {
                yield return new ValidationResult("商户订单号、QQ钱包订单号、商户退款单号和QQ钱包退款单号不能同时为空");
            }

            yield return ValidationResult.Success;
        }
    }
}
