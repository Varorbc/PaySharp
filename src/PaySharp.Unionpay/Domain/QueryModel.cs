using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Unionpay.Domain
{
    public class QueryModel : BaseModel, IValidatableObject
    {
        public QueryModel()
        {
            BizType = "000000";
            TxnType = "00";
        }

        /// <summary>
        /// 查询流水号	
        /// </summary>
        public string QueryId { get; set; }

        /// <summary>
        /// 商户订单号，不应含“-”或“_”
        /// </summary>
        [StringLength(40, MinimumLength = 8, ErrorMessage = "商户订单号最小长度为8位,最大长度为40位")]
        public string OrderId { get; set; }

        /// <summary>
        /// 保留域
        /// </summary>
        [StringLength(2048, ErrorMessage = "保留域最大长度为2048位")]
        public string Reserved { get; set; }

        /// <summary>
        /// 控制规则
        /// </summary>
        public string CtrlRule { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(OrderId) && string.IsNullOrEmpty(QueryId))
            {
                yield return new ValidationResult("商户订单号和查询流水号不能同时为空");
            }

            yield return ValidationResult.Success;
        }
    }
}
