using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Alipay.Domain
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class BillDownloadModel
    {
        /// <summary>
        /// 账单类型，商户通过接口或商户经开放平台授权后其所属服务商通过接口可以获取以下
        /// 账单类型：trade、signcustomer；trade指商户基于支付宝交易收单的业务账单；
        /// signcustomer是指基于商户支付宝余额收入及支出等资金变动的帐务账单；
        /// </summary>
        [Required(ErrorMessage = "请设置账单类型")]
        [StringLength(10, ErrorMessage = "账单类型最大长度为10位")]
        public string BillType { get; set; }

        /// <summary>
        /// 账单时间：日账单格式为yyyy-MM-dd，月账单格式为yyyy-MM。
        /// </summary>
        [Required(ErrorMessage = "请设置账单时间")]
        [StringLength(15, ErrorMessage = "账单时间最大长度为15位")]
        public string BillDate { get; set; }
    }
}
