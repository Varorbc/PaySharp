using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PaySharp.Core;

namespace PaySharp.Allinpay.Domain
{
    public class QueryModel : IValidatableObject
    {
        /// <summary>
        /// 商户交易单号
        /// </summary>
        [ReName(Name = "reqsn")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 交易单号
        /// </summary>
        [ReName(Name = "trxid")]
        public string TradeNo { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(OutTradeNo) && string.IsNullOrEmpty(TradeNo))
            {
                yield return new ValidationResult("商户订单号和交易单号不能同时为空");
            }

            yield return ValidationResult.Success;
        }
    }
}
