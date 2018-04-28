using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Alipay.Domain
{
    public class RefundModel : QueryModel
    {
        /// <summary>
        /// 需要退款的金额，该金额不能大于订单金额,单位为元
        /// </summary>
        public double RefundAmount { get; set; }

        /// <summary>
        /// 订单退款币种信息，非外币交易，不能传入退款币种信息
        /// </summary>
        [StringLength(8, ErrorMessage = "币种信息最大长度为8位")]
        public string RefundCurrency { get; set; }

        /// <summary>
        /// 退款的原因说明
        /// </summary>
        [StringLength(256, ErrorMessage = "退款的原因说明最大长度为256位")]
        public string RefundReason { get; set; }

        /// <summary>
        /// 标识一次退款请求，同一笔交易多次退款需要保证唯一，如需部分退款，则此参数必传。
        /// </summary>
        [StringLength(64, ErrorMessage = "退款请求号最大长度为64位")]
        [Required(ErrorMessage = "请设置退款请求号")]
        [JsonProperty("out_request_no")]
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 卖家端自定义的的操作员编号
        /// </summary>
        [StringLength(28, ErrorMessage = "卖家端自定义的的操作员编号最大长度为28位")]
        public string OperatorId { get; set; }

        /// <summary>
        /// 商户的门店编号
        /// </summary>
        [StringLength(32, ErrorMessage = "门店编号最大长度为32位")]
        public string StoreId { get; set; }

        /// <summary>
        /// 商户的终端编号
        /// </summary>
        [StringLength(32, ErrorMessage = "终端编号最大长度为32位")]
        public string TerminalId { get; set; }

        /// <summary>
        /// 退款包含的商品列表信息
        /// </summary>
        public List<Goods> GoodsDetail { get; set; }
    }
}
