using PaySharp.Core.Request;
using Newtonsoft.Json;
using System;

namespace PaySharp.Alipay.Response
{
    public class TransferResponse : BaseResponse
    {
        /// <summary>
        /// 支付宝转账单据号，成功一定返回，失败可能不返回也可能返回。
        /// </summary>
        [JsonProperty("order_id")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 商户转账唯一订单号。发起转账来源方定义的转账单据ID，用于将转账回执通知给来源方。 
        /// 不同来源方给出的ID可以重复，同一个来源方必须保证其ID的唯一性。 
        /// 只支持半角英文、数字，及“-”、“_”。
        /// </summary>
        [JsonProperty("out_biz_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 支付时间：格式为yyyy-MM-dd HH:mm:ss，仅转账成功返回。
        /// </summary>
        public DateTime? PayDate { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
