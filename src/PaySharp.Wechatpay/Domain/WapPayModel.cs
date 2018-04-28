using PaySharp.Core;
using PaySharp.Core.Utils;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Wechatpay.Domain
{
    public class WapPayModel : BasePayModel
    {
        public WapPayModel()
        {
            TradeType = "MWEB";
        }

        /// <summary>
        /// 交易类型
        /// </summary>
        public string TradeType { get; private set; }

        /// <summary>
        /// 用户IP
        /// </summary>
        [Required(ErrorMessage = "请设置用户IP")]
        [StringLength(16, ErrorMessage = "用户IP最大长度为16位")]
        public string SpbillCreateIp { get; set; } = HttpUtil.RemoteIpAddress;

        /// <summary>
        /// 商品ID
        /// </summary>
        [StringLength(32, ErrorMessage = "商品ID最大长度为32位")]
        public string ProductId { get; set; }

        /// <summary>
        /// 用户标识，此参数为微信用户在商户对应appid下的唯一标识。
        /// </summary>
        [ReName(Name = "openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 场景信息,该字段用于上报支付的场景信息,针对H5支付有以下三种场景,请根据对应场景上报
        /// </summary>
        [StringLength(256, ErrorMessage = "场景信息最大长度为256位")]
        [Required(ErrorMessage = "请设置场景信息")]
        public string SceneInfo { get; set; }
    }
}
