using ICanPay.Core;
using System.ComponentModel.DataAnnotations;

namespace ICanPay.Wechatpay.Domain
{
    public class PublicPayModel : BasePayModel
    {
        public PublicPayModel()
            : base("JSAPI")
        {

        }

        /// <summary>
        /// 终端(用户端)IP
        /// </summary>
        [Required(ErrorMessage = "请设置终端IP")]
        [StringLength(16, ErrorMessage = "终端IP最大长度为16位")]
        public string SpbillCreateIp { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        [StringLength(32, ErrorMessage = "商品ID最大长度为32位")]
        public string ProductId { get; set; }

        /// <summary>
        /// 用户标识，此参数为微信用户在商户对应appid下的唯一标识。
        /// </summary>
        [ReName(Name = Constant.OPENID)]
        [Required(ErrorMessage = "请设置用户标识")]
        public string OpenId { get; set; }
    }
}
