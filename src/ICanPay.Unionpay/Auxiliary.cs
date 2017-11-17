using ICanPay.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICanPay.Unionpay
{
    public class Auxiliary : IAuxiliary
    {
        /// <summary>
        /// 商户订单号，不应含“-”或“_”
        /// </summary>
        [Necessary(GatewayAuxiliaryType.Query)]
        [ReName(Name = Constant.ORDERID)]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "商户订单号最小长度为8位,最大长度为40位")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 撤销单号
        /// </summary>
        [Necessary(GatewayAuxiliaryType.Cancel)]
        [ReName(Name = Constant.ORDERID)]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "商户订单号最小长度为8位,最大长度为40位")]
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 订单发送时间 格式 年年年年月月日日时时分分秒秒
        /// </summary>
        [Required]
        public string TxnTime { get; set; }

        /// <summary>
        /// 原消费的QueryId
        /// </summary>
        [Necessary(GatewayAuxiliaryType.Cancel)]
        [ReName(Name = Constant.ORIGQRYID)]
        [StringLength(21, MinimumLength = 21, ErrorMessage = "原消费的QueryId长度为21位")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 需要退款的金额，单位为元
        /// </summary>
        [ReName(Name = Constant.TXNAMT)]
        [Necessary(GatewayAuxiliaryType.Cancel, ErrorMessage = "请设置退款金额")]
        public double? RefundAmount
        {
            get => _refundAmount;
            set
            {
                if (value.HasValue)
                {
                    _refundAmount = value.Value * 100;
                }
            }
        }
        private double? _refundAmount;

        /// <summary>
        /// 商户自定义保留域，交易应答时会原样返回
        /// </summary>
        [StringLength(1024, ErrorMessage = "商户自定义保留域最大长度为1024位")]
        public string ReqReserved { get; set; }

        public string RefundNo { get; set; }

        /// <summary>
        /// 退款的原因说明
        /// </summary>
        [StringLength(256, ErrorMessage = "退款的原因说明最大长度为256位")]
        public string RefundReason { get; set; }

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
            //if (string.IsNullOrEmpty(OutTradeNo) && string.IsNullOrEmpty(TradeNo))
            //{
            //    throw new ArgumentNullException("商户订单号和支付宝订单号不可同时为空");
            //}

            return true;
        }
    }
}
