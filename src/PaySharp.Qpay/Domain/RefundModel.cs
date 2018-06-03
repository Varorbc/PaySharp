using PaySharp.Core;
using PaySharp.Core.Utils;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Qpay.Domain
{
    public class RefundModel : IValidatableObject
    {
        /// <summary>
        /// 商户订单号
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
        /// 商户退款单号	
        /// </summary>
        [Required(ErrorMessage = "请设置商户退款单号")]
        [StringLength(32, ErrorMessage = "商户退款单号最大长度为32位")]
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 退款金额	，单位为分，详见支付金额
        /// </summary>
        [ReName(Name = "refund_fee")]
        public int RefundAmount { get; set; }

        /// <summary>
        /// 操作员ID
        /// </summary>
        [Required(ErrorMessage = "请设置操作员ID")]
        [StringLength(32, ErrorMessage = "操作员ID最大长度为32位")]
        public string OpUserId { get; set; }

        /// <summary>
        /// 操作员密码
        /// </summary>
        [Required(ErrorMessage = "请设置操作员密码")]
        [StringLength(32, ErrorMessage = "退款原因最大长度为32位")]
        public string OpUserPasswd
        {
            get
            {
                return _opUserPasswd;
            }
            set
            {
                _opUserPasswd = EncryptUtil.MD5(value).ToLower();
            }
        }
        private string _opUserPasswd;

        /// <summary>
        /// 退款资金来源
        /// REFUND_SOURCE_UNSETTLED_FUNDS---未结算资金退款（默认使用未结算资金退款）
        /// REFUND_SOURCE_RECHARGE_FUNDS---可用现金账户资金退款
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
                yield return new ValidationResult("商户订单号和QQ钱包订单号不能同时为空");
            }

            yield return ValidationResult.Success;
        }
    }
}
