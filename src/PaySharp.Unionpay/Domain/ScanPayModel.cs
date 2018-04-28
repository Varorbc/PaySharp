using System.ComponentModel.DataAnnotations;

namespace PaySharp.Unionpay.Domain
{
    public class ScanPayModel : BasePayModel
    {
        public ScanPayModel()
        {
            BizType = "000000";
            TxnType = "01";
            TxnSubType = "07";
        }

        /// <summary>
        /// 终端信息
        /// </summary>
        [StringLength(300, ErrorMessage = "终端信息最大长度为300位")]
        public string TermInfo { get; set; }

        /// <summary>
        /// 终端号
        /// </summary>
        public string TermId { get; set; }
    }
}
