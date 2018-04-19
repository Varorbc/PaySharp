using PaySharp.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Unionpay
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
        [Required(ErrorMessage = "请设置订单发送时间")]
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

        public string RefundNo { get => null; set => throw new NotImplementedException(); }

        public string RefundReason { get => null; set => throw new NotImplementedException(); }

        /// <summary>
        /// 文件类型
        /// </summary>
        public string FileType => "00";

        /// <summary>
        /// 清算日期 格式 月月日日
        /// 为银联和入网机构间的交易结算日期。
        /// 一般前一日23点至当天23点为一个清算日。
        /// 也就是23点前的交易，当天23点之后开始结算，23点之后的交易，要第二天23点之后才会结算。
        /// </summary>
        [Necessary(GatewayAuxiliaryType.BillDownload, ErrorMessage = "请设置清算日期")]
        [ReName(Name = Constant.SETTLEDATE)]
        public string BillDate { get; set; }

        public bool Validate(GatewayAuxiliaryType gatewayAuxiliaryType) => true;
    }
}
