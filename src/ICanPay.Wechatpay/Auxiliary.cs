using ICanPay.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICanPay.Wechatpay
{
    public class Auxiliary : IAuxiliary
    {
        /// <summary>
        /// 商户系统内部订单号，要求32个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一。
        /// </summary>
        [StringLength(32, ErrorMessage = "商户系统内部订单号最大长度为32位")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 微信的订单号，建议优先使用
        /// </summary>
        [ReName(Name = Constant.TRANSACTION_ID)]
        [StringLength(32, ErrorMessage = "微信的订单号最大长度为32位")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 商户退款单号	
        /// </summary>
        [StringLength(64, ErrorMessage = "商户退款单号最大长度为64位")]
        [Necessary(GatewayAuxiliaryType.Refund)]
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 微信退款单号
        /// </summary>
        [StringLength(32, ErrorMessage = "微信退款单号最大长度为32位")]
        [ReName(Name = Constant.REFUND_ID)]
        public string RefundNo { get; set; }

        /// <summary>
        /// 标价金额,订单总金额，单位为元，详见支付金额
        /// </summary>
        [ReName(Name = Constant.TOTAL_FEE)]
        [Necessary(GatewayAuxiliaryType.Refund)]
        public double Amount
        {
            get => _amount;
            set => _amount = value * 100;
        }
        private double _amount;

        /// <summary>
        /// 退款金额
        /// </summary>
        [ReName(Name = Constant.REFUND_FEE)]
        [Necessary(GatewayAuxiliaryType.Refund)]
        public double RefundAmount { get; set; }

        /// <summary>
        /// 货币种类	
        /// </summary>
        public string RefundFeeType { get; set; } = Constant.CNY;

        /// <summary>
        /// 退款原因
        /// </summary>
        [StringLength(80, ErrorMessage = "退款原因最大长度为80位")]
        [ReName(Name = Constant.REFUND_DESC)]
        public string RefundReason { get; set; }

        /// <summary>
        /// 退款资金来源
        /// 仅针对老资金流商户使用
        /// REFUND_SOURCE_UNSETTLED_FUNDS---未结算资金退款（默认使用未结算资金退款）
        /// REFUND_SOURCE_RECHARGE_FUNDS---可用余额退款
        /// </summary>
        [StringLength(30, ErrorMessage = "退款资金来源最大长度为30位")]
        [ReName(Name = Constant.REFUND_DESC)]
        public string RefundAccount { get; set; }

        /// <summary>
        /// 偏移量，当部分退款次数超过10次时可使用，表示返回的查询结果从这个偏移量开始取记录
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// 对账单日期，下载对账单的日期，格式：20140603
        /// </summary>
        public string BillDate { get; set; }

        /// <summary>
        /// 账单类型	，
        /// ALL，返回当日所有订单信息，默认值
        /// SUCCESS，返回当日成功支付的订单
        /// REFUND，返回当日退款订单
        /// </summary>
        public string BillType { get; set; }

        public bool Validate(GatewayAuxiliaryType gatewayAuxiliaryType)
        {
            if (gatewayAuxiliaryType != GatewayAuxiliaryType.BillDownload)
            {
                if (string.IsNullOrEmpty(OutTradeNo) && string.IsNullOrEmpty(TradeNo))
                {
                    throw new ArgumentNullException("商户订单号和支付宝订单号不可同时为空");
                }
            }

            return true;
        }
    }
}
