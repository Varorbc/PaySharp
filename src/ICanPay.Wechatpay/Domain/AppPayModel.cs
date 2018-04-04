using ICanPay.Core.Utils;
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
        /// 用户IP
        /// </summary>
        [Required(ErrorMessage = "请设置用户IP")]
        [StringLength(16, ErrorMessage = "用户IP最大长度为16位")]
        public string SpbillCreateIp { get; set; } = HttpUtil.RemoteIpAddress;

        /// <summary>
        /// 场景信息,该字段用于上报场景信息，目前支持上报实际门店信息。该字段为JSON对象数据，对象格式为{"store_info":{"id": "门店ID","name": "名称","area_code": "编码","address": "地址" }}
        /// </summary>
        [StringLength(256, ErrorMessage = "场景信息最大长度为256位")]
        public string SceneInfo { get; set; }
    }
}
