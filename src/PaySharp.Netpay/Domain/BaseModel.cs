using System;
using System.ComponentModel.DataAnnotations;
using PaySharp.Core;
using PaySharp.Core.Utils;

namespace PaySharp.Netpay.Domain
{
    /// <summary>
    /// 基础模型
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// 消息编号
        /// </summary>
        [StringLength(64, ErrorMessage = "消息编号最大长度为64位")]
        public string MsgId { get; set; } = Util.GenerateNonceStr();

        /// <summary>
        /// 消息类型
        /// </summary>
        /// <remarks>
        /// 微信：wx.appPreOrder(存量商户需改为新的msgType)
        /// 支付宝：trade.precreate
        /// 全民付：qmf.order
        /// 银联云闪付(走银联全渠道)：uac.appOrder
        /// ApplePay支付：applepay.order
        /// 查询订单：query
        /// </remarks>
        [Required(ErrorMessage = "请设置消息类型")]
        [StringLength(64, MinimumLength = 1, ErrorMessage = "消息类型,最小长度为1位,最大长度为64位")]
        public string MsgType { get; set; }

        /// <summary>
        /// 报文请求时间
        /// </summary>
        [Required(ErrorMessage = "请设置报文请求时间")]
        public string RequestTimestamp { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        /// <summary>
        /// 商户的交易订单号
        /// </summary>
        [ReName(Name = "merOrderId")]
        [StringLength(32, MinimumLength = 6, ErrorMessage = "商户的交易订单号,最小长度为6位,最大长度为32位")]
        [Required(ErrorMessage = "请设置商户的交易订单号")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 请求系统预留字段
        /// </summary>
        public string SrcReserve { get; set; }
    }
}
