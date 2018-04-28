using System.ComponentModel.DataAnnotations;

namespace PaySharp.Alipay.Domain
{
    /// <summary>
    /// 手机网站支付模型
    /// </summary>
    public class WapPayModel : BasePayModel
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public WapPayModel()
            : base("QUICK_WAP_WAY")
        {
        }

        /// <summary>
        /// 获取用户授权信息，可实现如免登功能。
        /// 获取方法请查阅：用户信息授权 https://docs.open.alipay.com/289/105656
        /// </summary>
        [StringLength(40, ErrorMessage = "用户授权信息最大长度为40位")]
        public string AuthToken { get; set; }

        /// <summary>
        /// 添加该参数后在h5支付收银台会出现返回按钮，可用于用户付款中途退出并返回到该参数指定的商户网站地址。
        /// 注：该参数对支付宝钱包标准收银台下的跳转不生效。
        /// </summary>
        [StringLength(400, ErrorMessage = "退出地址最大长度为400位")]
        public string QuitUrl { get; set; }
    }
}
