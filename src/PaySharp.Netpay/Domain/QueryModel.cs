using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PaySharp.Core;

namespace PaySharp.Netpay.Domain
{
    public class QueryModel : BaseModel, IValidatableObject
    {
        /// <summary>
        /// 交易单号
        /// </summary>
        [ReName(Name = "targetOrderId")]
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
