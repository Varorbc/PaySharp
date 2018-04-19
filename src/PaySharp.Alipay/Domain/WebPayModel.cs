using System.ComponentModel.DataAnnotations;

namespace PaySharp.Alipay.Domain
{
    /// <summary>
    /// 电脑网站支付模型
    /// </summary>
    public class WebPayModel : BasePayModel
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public WebPayModel()
            : base("FAST_INSTANT_TRADE_PAY")
        {
        }

        /// <summary>
        /// 订单包含的商品列表信息，Json格式： {"show_url":"https://或http://打头的商品的展示地址"} ，在支付时，可点击商品名称跳转到该地址
        /// </summary>
        public Goods[] GoodsDetail { get; set; }

        /// <summary>
        /// 获取用户授权信息，可实现如免登功能。
        /// 获取方法请查阅：用户信息授权 https://docs.open.alipay.com/289/105656
        /// </summary>
        [StringLength(40, ErrorMessage = "用户授权信息最大长度为40位")]
        public string AuthToken { get; set; }

        /// <summary>
        /// PC扫码支付的方式，支持前置模式和跳转模式。
        /// 前置模式是将二维码前置到商户的订单确认页的模式。需要商户在自己的页面中以iframe方式请求支付宝页面。具体分为以下几种：
        /// 0：订单码-简约前置模式，对应iframe宽度不能小于600px，高度不能小于300px；
        /// 1：订单码-前置模式，对应iframe宽度不能小于300px，高度不能小于600px；
        /// 3：订单码-迷你前置模式，对应iframe宽度不能小于75px，高度不能小于75px；
        /// 4：订单码-可定义宽度的嵌入式二维码，商户可根据需要设定二维码的大小。
        /// 跳转模式下，用户的扫码界面是由支付宝生成的，不在商户的域名下。
        /// 2：订单码-跳转模式
        /// </summary>
        [StringLength(2, ErrorMessage = "PC扫码支付的方式最大长度为2位")]
        public string QrPayMode { get; set; }

        /// <summary>
        /// 商户自定义二维码宽度 注：qr_pay_mode=4时该参数生效
        /// </summary>
        [StringLength(4, ErrorMessage = "商户自定义二维码宽度最大长度为4位")]
        public string QrcodeWidth { get; set; }
    }
}
