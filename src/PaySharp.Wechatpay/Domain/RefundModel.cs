using PaySharp.Core;
using PaySharp.Core.Utils;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Wechatpay.Domain
{
    public class RefundModel : IValidatableObject
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        [StringLength(32, ErrorMessage = "商户订单号最大长度为32位")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 微信订单号，和商户订单号不能同时为空
        /// </summary>
        [ReName(Name = "transaction_id")]
        [StringLength(32, ErrorMessage = "微信订单号最大长度为32位")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 商户退款单号	
        /// </summary>
        [Required(ErrorMessage = "请设置商户退款单号")]
        [StringLength(64, ErrorMessage = "商户退款单号最大长度为64位")]
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 订单金额，单位为分，详见支付金额
        /// </summary>
        [ReName(Name = "total_fee")]
        public int TotalAmount { get; set; }

        /// <summary>
        /// 退款金额	，单位为分，详见支付金额
        /// </summary>
        [ReName(Name = "refund_fee")]
        public int RefundAmount { get; set; }

        /// <summary>
        /// 退款货币种类，需与支付一致，或者不填。符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [ReName(Name = "refund_fee_type")]
        [StringLength(8, ErrorMessage = "退款货币种类最大长度为8位")]
        public string RefundAmountType { get; set; }

        /// <summary>
        /// 退款原因,若商户传入，会在下发给用户的退款消息中体现退款原因
        /// </summary>
        [StringLength(80, ErrorMessage = "退款原因最大长度为80位")]
        public string RefundDesc { get; set; }

        /// <summary>
        /// 退款资金来源
        /// 仅针对老资金流商户使用
        /// REFUND_SOURCE_UNSETTLED_FUNDS---未结算资金退款（默认使用未结算资金退款）
        /// REFUND_SOURCE_RECHARGE_FUNDS---可用余额退款
        /// </summary>
        [StringLength(30, ErrorMessage = "退款资金来源最大长度为30位")]
        public string RefundAccount { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; } = Util.GenerateNonceStr();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(OutTradeNo) && string.IsNullOrEmpty(TradeNo))
            {
                yield return new ValidationResult("商户订单号和微信订单号不能同时为空");
            }

            yield return ValidationResult.Success;
        }
    }
}
