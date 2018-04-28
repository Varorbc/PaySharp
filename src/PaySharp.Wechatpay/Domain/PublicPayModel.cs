using PaySharp.Core;
using PaySharp.Core.Utils;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Wechatpay.Domain
{
    public class PublicPayModel : BasePayModel
    {
        public PublicPayModel()
        {
            TradeType = "JSAPI";
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
        [Required(ErrorMessage = "请设置用户标识")]
        public string OpenId { get; set; }

        /// <summary>
        /// 场景信息,该字段用于上报场景信息，目前支持上报实际门店信息。该字段为JSON对象数据，对象格式为{"store_info":{"id": "门店ID","name": "名称","area_code": "编码","address": "地址" }}
        /// </summary>
        [StringLength(256, ErrorMessage = "场景信息最大长度为256位")]
        public string SceneInfo { get; set; }
    }
}
