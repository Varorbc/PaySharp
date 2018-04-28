using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Alipay.Domain
{
    public class RefundQueryModel : QueryModel
    {
        /// <summary>
        /// 请求退款接口时，传入的退款请求号，如果在退款请求时未传入，则该值为创建交易时的外部交易号
        /// </summary>
        [Required(ErrorMessage = "请设置退款请求号")]
        [StringLength(64, ErrorMessage = "退款请求号最大长度为64位")]
        [JsonProperty("out_request_no")]
        public string OutRefundNo { get; set; }
    }
}
