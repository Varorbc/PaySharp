using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PaySharp.Alipay.Domain
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class TradeFundBill
    {
        /// <summary>
        /// 交易使用的资金渠道,详见 https://doc.open.alipay.com/doc2/detail?treeId=26&articleId=103259&docType=1
        /// </summary>
        public string FundChannel { get; set; }

        /// <summary>
        /// 银行卡支付时的银行代码
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 该支付工具类型所使用的金额
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// 渠道实际付款金额
        /// </summary>
        public double RealAmount { get; set; }
    }
}
