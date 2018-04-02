using System.ComponentModel.DataAnnotations;

namespace ICanPay.Wechatpay.Domain
{
    public class AppPayModel : BasePayModel
    {
        public AppPayModel()
            : base("APP")
        {

        }

        /// <summary>
        /// 终端(用户端)IP
        /// </summary>
        [Required(ErrorMessage = "请设置终端IP")]
        [StringLength(16, ErrorMessage = "终端IP最大长度为16位")]
        public string SpbillCreateIp { get; set; }
    }
}
