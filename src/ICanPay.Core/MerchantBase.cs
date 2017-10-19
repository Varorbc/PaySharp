using System.ComponentModel.DataAnnotations;

namespace ICanPay.Core
{
    public abstract class MerchantBase
    {
        #region 属性

        /// <summary>
        /// 应用ID
        /// </summary>
        [Required(ErrorMessage = "请输入支付机构提供的应用编号")]
        public string AppId { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// 签名类型
        /// </summary>
        [Required(ErrorMessage = "请输入签名类型")]
        public string SignType { get; set; }

        /// <summary>
        /// 网关回发通知URL
        /// </summary>
        [Required(ErrorMessage = "请输入网关回发通知URL")]
        public string NotifyUrl { get; set; }

        #endregion
    }
}
