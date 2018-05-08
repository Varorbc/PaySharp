using PaySharp.Core.Utils;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Wechatpay.Domain
{
    public class FundFlowDownloadModel
    {
        /// <summary>
        /// 资金账户类型
        /// 账单的资金来源账户：
        /// Basic  基本账户
        /// Operation 运营账户
        /// Fees 手续费账户
        /// </summary>
        [Required(ErrorMessage = "请设置资金账户类型")]
        [StringLength(8, ErrorMessage = "资金账户类型最大长度为8位")]
        public string AccountType { get; set; } = "Basic";

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
