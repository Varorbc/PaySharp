using PaySharp.Core;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Unionpay.Domain
{
    public class BillDownloadModel : BaseModel
    {
        public BillDownloadModel()
        {
            TxnType = "76";
            TxnSubType = "01";
            BizType = "000000";
        }

        /// <summary>
        /// 清算日期，格式MMDD
        /// </summary>
        [ReName(Name = "settleDate")]
        [Required(ErrorMessage = "请设置清算日期")]
        public string BillDate { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        [Required(ErrorMessage = "请设置文件类型")]
        public string FileType { get; set; } = "00";

        /// <summary>
        /// 商户自定义保留域，交易应答时会原样返回
        /// </summary>
        [StringLength(1024, ErrorMessage = "商户自定义保留域最大长度为1024位")]
        public string ReqReserved { get; set; }
    }
}
