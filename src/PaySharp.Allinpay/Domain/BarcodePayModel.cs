using System.ComponentModel.DataAnnotations;

namespace PaySharp.Allinpay.Domain
{
    public class BarcodePayModel : BasePayModel
    {
        /// <summary>
        /// 支付授权码
        /// </summary>
        [StringLength(32, ErrorMessage = "备注最大长度为32位")]
        public string AuthCode { get; set; }
    }
}
