using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Alipay.Domain
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class TransferQueryModel : IValidatableObject
    {
        /// <summary>
        /// 商户转账唯一订单号：发起转账来源方定义的转账单据ID。 
        /// 和支付宝转账单据号不能同时为空。当和支付宝转账单据号同时提供时，将用支付宝转账单据号进行查询，忽略本参数
        /// </summary>
        [StringLength(64, ErrorMessage = "商户转账唯一订单号最大长度为64位")]
        [JsonProperty("out_biz_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 支付宝转账单据号：和商户转账唯一订单号不能同时为空。当和商户转账唯一订单号同时提供时，将用本参数进行查询，忽略商户转账唯一订单号。
        /// </summary>
        [StringLength(64, ErrorMessage = "支付宝转账单据号最大长度为64位")]
        [JsonProperty("order_id")]
        public string TradeNo { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(OutTradeNo) && string.IsNullOrEmpty(TradeNo))
            {
                yield return new ValidationResult("商户转账唯一订单号和支付宝转账单据号不能同时为空");
            }

            yield return ValidationResult.Success;
        }
    }
}
