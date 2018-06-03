using PaySharp.Core;
using PaySharp.Core.Utils;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Wechatpay.Domain
{
    public class RefundQueryModel : IValidatableObject
    {
        /// <summary>
        /// 商户订单号
        /// 微信订单号查询的优先级是： RefundNo > OutRefundNo > TradeNo > OutTradeNo
        /// </summary>
        [StringLength(32, ErrorMessage = "商户订单号最大长度为32位")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 微信订单号
        /// </summary>
        [ReName(Name = "transaction_id")]
        [StringLength(32, ErrorMessage = "微信订单号最大长度为32位")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 商户退款单号	
        /// </summary>
        [StringLength(64, ErrorMessage = "商户退款单号最大长度为64位")]
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 微信退款单号	
        /// </summary>
        [ReName(Name = "refund_id")]
        [StringLength(32, ErrorMessage = "微信退款单号最大长度为32位")]
        public string RefundNo { get; set; }

        /// <summary>
        /// 偏移量，当部分退款次数超过10次时可使用，表示返回的查询结果从这个偏移量开始取记录
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; } = Util.GenerateNonceStr();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(OutTradeNo) && string.IsNullOrEmpty(TradeNo)
                && string.IsNullOrEmpty(OutRefundNo) && string.IsNullOrEmpty(RefundNo))
            {
                yield return new ValidationResult("商户订单号、微信订单号、商户退款单号和微信退款单号不能同时为空");
            }

            yield return ValidationResult.Success;
        }
    }
}
