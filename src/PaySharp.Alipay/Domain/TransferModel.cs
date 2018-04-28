using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Alipay.Domain
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class TransferModel
    {
        /// <summary>
        /// 商户转账唯一订单号。发起转账来源方定义的转账单据ID，用于将转账回执通知给来源方。 
        /// 不同来源方给出的ID可以重复，同一个来源方必须保证其ID的唯一性。 
        /// 只支持半角英文、数字，及“-”、“_”。
        /// </summary>
        [StringLength(64, ErrorMessage = "商户转账唯一订单号最大长度为64位")]
        [Required(ErrorMessage = "请设置商户转账唯一订单号")]
        [JsonProperty("out_biz_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 收款方账户类型。可取值： 
        /// 1、ALIPAY_USERID：支付宝账号对应的支付宝唯一用户号。以2088开头的16位纯数字组成。 
        /// 2、ALIPAY_LOGONID：支付宝登录号，支持邮箱和手机号格式。
        /// </summary>
        [StringLength(20, ErrorMessage = "收款方账户类型最大长度为20位")]
        [Required(ErrorMessage = "请设置收款方账户类型")]
        public string PayeeType { get; set; }

        /// <summary>
        /// 收款方账户。与payee_type配合使用。付款方和收款方不能是同一个账户。
        /// </summary>
        [StringLength(100, ErrorMessage = "收款方账户最大长度为100位")]
        [Required(ErrorMessage = "请设置收款方账户")]
        public string PayeeAccount { get; set; }

        /// <summary>
        /// 转账金额，单位：元。 
        /// 只支持2位小数，小数点前最大支持13位，金额必须大于等于0.1元。 
        /// 最大转账金额以实际签约的限额为准。
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// 付款方姓名（最长支持100个英文/50个汉字）。
        /// 显示在收款方的账单详情页。如果该字段不传，则默认显示付款方的支付宝认证姓名或单位名称。
        /// </summary>
        [StringLength(100, ErrorMessage = "付款方姓名最大长度为100位")]
        public string PayerShowName { get; set; }

        /// <summary>
        /// 收款方真实姓名（最长支持100个英文/50个汉字）。 
        /// 如果本参数不为空，则会校验该账户在支付宝登记的实名是否与收款方真实姓名一致。
        /// </summary>
        [StringLength(100, ErrorMessage = "收款方真实姓名最大长度为100位")]
        public string PayeeRealName { get; set; }

        /// <summary>
        /// 转账备注（支持200个英文/100个汉字）。
        /// 当付款方为企业账户，且转账金额达到（大于等于）50000元，remark不能为空。
        /// 收款方可见，会展示在收款用户的收支详情中。
        /// </summary>
        [StringLength(200, ErrorMessage = "收款方真实姓名最大长度为200位")]
        public string Remark { get; set; }
    }
}
