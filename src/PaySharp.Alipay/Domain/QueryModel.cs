using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Alipay.Domain
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class QueryModel : IValidatableObject
    {
        /// <summary>
        /// 订单支付时传入的商户订单号,和支付宝交易号不能同时为空。 
        /// TradeNo,OutTradeNo如果同时存在优先取TradeNo
        /// </summary>
        [StringLength(64, ErrorMessage = "商户订单号最大长度为64位")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 支付宝交易号，和商户订单号不能同时为空
        /// </summary>
        [StringLength(64, ErrorMessage = "支付宝交易号最大长度为64位")]
        public string TradeNo { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(OutTradeNo) && string.IsNullOrEmpty(TradeNo))
            {
                yield return new ValidationResult("商户订单号和支付宝交易号不能同时为空");
            }

            yield return ValidationResult.Success;
        }
    }
}
