using PaySharp.Core.Utils;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Wechatpay.Domain
{
    public class BillDownloadModel
    {
        /// <summary>
        /// 账单类型
        /// ALL，返回当日所有订单信息，默认值
        /// SUCCESS，返回当日成功支付的订单
        /// REFUND，返回当日退款订单
        /// RECHARGE_REFUND，返回当日充值退款订单
        /// </summary>
        [Required(ErrorMessage = "请设置账单类型")]
        [StringLength(8, ErrorMessage = "账单类型最大长度为8位")]
        public string BillType { get; set; } = "ALL";

        /// <summary>
        /// 下载对账单的日期，格式"yyyyMMdd"	
        /// </summary>
        [Required(ErrorMessage = "请设置下载对账单的日期")]
        [StringLength(8, ErrorMessage = "下载对账单的日期最大长度为8位")]
        public string BillDate { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; } = Util.GenerateNonceStr();
    }
}
