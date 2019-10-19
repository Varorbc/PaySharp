using System.ComponentModel.DataAnnotations;
using PaySharp.Core.Utils;

namespace PaySharp.Qpay.Domain
{
    public class BillDownloadModel
    {
        /// <summary>
        /// 账单类型
        /// ALL，返回当日所有交易账单
        /// SUCCESS，返回当日支付账单
        /// REFUND，返回当日退款账单
        /// RECHAR，返回当日现金账户退款账单
        /// </summary>
        [Required(ErrorMessage = "请设置账单类型")]
        [StringLength(32, ErrorMessage = "账单类型最大长度为32位")]
        public string BillType { get; set; } = "ALL";

        /// <summary>
        /// 下载对账单的日期，格式"YYYYMMDD"	
        /// </summary>
        [Required(ErrorMessage = "请设置下载对账单的日期")]
        [StringLength(32, ErrorMessage = "下载对账单的日期最大长度为32位")]
        public string BillDate { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; } = Util.GenerateNonceStr();
    }
}
