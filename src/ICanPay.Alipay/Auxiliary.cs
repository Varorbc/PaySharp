using ICanPay.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICanPay.Alipay
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Auxiliary : IAuxiliary
    {
        /// <summary>
        /// 订单支付时传入的商户订单号,和支付宝交易号不能同时为空。 
        /// trade_no,out_trade_no如果同时存在优先取trade_no
        /// </summary>
        [StringLength(64, ErrorMessage = "商户订单号最大长度为64位")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 支付宝交易号，和商户订单号不能同时为空
        /// </summary>
        [StringLength(64, ErrorMessage = "支付宝交易号最大长度为64位")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 请求退款接口时，传入的退款请求号，如果在退款请求时未传入，则该值为创建交易时的外部交易号
        /// 标识一次退款请求，同一笔交易多次退款需要保证唯一，如需部分退款，则此参数必传。
        /// </summary>
        [StringLength(64, ErrorMessage = "退款请求号最大长度为64位")]
        public string OutRequestNo { get; set; }

        /// <summary>
        /// 卖家端自定义的的操作员 ID
        /// </summary>
        [StringLength(28, ErrorMessage = "操作员编号最大长度为28位")]
        public string OperatorId { get; set; }

        /// <summary>
        /// 需要退款的金额，该金额不能大于订单金额,单位为元，支持两位小数
        /// </summary>
        [Range(0.01, 100000000, ErrorMessage = "需要退款的金额超出范围")]
        public double RefundAmount { get; set; }

        /// <summary>
        /// 退款的原因说明
        /// </summary>
        [StringLength(256, ErrorMessage = "退款的原因说明最大长度为256位")]
        public string RefundReason { get; set; }

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
        /// 账单类型，商户通过接口或商户经开放平台授权后其所属服务商通过接口可以获取以下
        /// 账单类型：trade、signcustomer；trade指商户基于支付宝交易收单的业务账单；
        /// signcustomer是指基于商户支付宝余额收入及支出等资金变动的帐务账单；
        /// </summary>
        [StringLength(10, ErrorMessage = "账单类型最大长度为10位")]
        [Necessary(GatewayAuxiliaryType.BillDownload, ErrorMessage = "请设置账单类型")]
        public string BillType { get; set; }

        /// <summary>
        /// 账单时间：日账单格式为yyyy-MM-dd，月账单格式为yyyy-MM。
        /// </summary>
        [StringLength(15, ErrorMessage = "账单时间最大长度为15位")]
        [Necessary(GatewayAuxiliaryType.BillDownload, ErrorMessage = "请设置账单时间")]
        public string BillDate { get; set; }

        public bool Validate(GatewayAuxiliaryType gatewayAuxiliaryType)
        {
            if (gatewayAuxiliaryType == GatewayAuxiliaryType.Query ||
                gatewayAuxiliaryType == GatewayAuxiliaryType.Close ||
                gatewayAuxiliaryType == GatewayAuxiliaryType.Cancel)
                if (string.IsNullOrEmpty(OutTradeNo) && string.IsNullOrEmpty(TradeNo))
                {
                    throw new ArgumentNullException("商户订单号和支付宝订单号不可同时为空");
                }

            return true;
        }
    }
}
