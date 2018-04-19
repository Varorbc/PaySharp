using PaySharp.Core.Utils;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Wechatpay.Domain
{
    public class BarcodePayModel : BasePayModel
    {
        /// <summary>
        /// 机器IP
        /// </summary>
        [Required(ErrorMessage = "请设置机器IP")]
        [StringLength(16, ErrorMessage = "机器IP最大长度为16位")]
        public string SpbillCreateIp { get; set; } = HttpUtil.LocalIpAddress;

        /// <summary>
        /// 授权码
        /// 扫码支付授权码，设备读取用户微信中的条码或者二维码信息
        /// （注：用户刷卡条形码规则：18位纯数字，以10、11、12、13、14、15开头）
        /// </summary>
        [Required(ErrorMessage = "请设置授权码")]
        [StringLength(128, ErrorMessage = "授权码最大长度为128位")]
        public string AuthCode { get; set; }

        /// <summary>
        /// 场景信息,该字段用于上报场景信息，目前支持上报实际门店信息。该字段为JSON对象数据，对象格式为{"store_info":{"id": "门店ID","name": "名称","area_code": "编码","address": "地址" }}
        /// </summary>
        [StringLength(256, ErrorMessage = "场景信息最大长度为256位")]
        public string SceneInfo { get; set; }
    }
}
