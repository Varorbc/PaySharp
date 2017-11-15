using ICanPay.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ICanPay.Alipay
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Order : IOrder
    {
        /// <summary>
        /// 商户订单号，64个字符以内、可包含字母、数字、下划线；需保证在商户端不重复
        /// </summary>
        [StringLength(64, ErrorMessage = "商户订单号最大长度为64位")]
        [Required(ErrorMessage = "请设置商户订单号")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 销售产品码，与支付宝签约的产品码名称。 
        /// </summary>
        [StringLength(64, ErrorMessage = "销售产品码最大长度为64位")]
        public string ProductCode { get; internal set; }

        /// <summary>
        /// 订单总金额，单位为元，精确到小数点后两位，取值范围[0.01,100000000]
        /// </summary>
        [JsonProperty(PropertyName = Constant.TOTAL_AMOUNT)]
        [Range(0.01, 100000000, ErrorMessage = "订单总金额超出范围")]
        [Required(ErrorMessage = "请设置订单总金额")]
        public double Amount { get; set; }

        /// <summary>
        /// 订单标题
        /// </summary>
        [StringLength(256, ErrorMessage = "订单标题最大长度为256位")]
        [Required(ErrorMessage = "请设置订单标题")]
        public string Subject { get; set; }

        /// <summary>
        /// 订单描述
        /// </summary>
        [StringLength(128, ErrorMessage = "商户订单号最大长度为128位")]
        public string Body { get; set; }

        /// <summary>
        /// 订单包含的商品列表信息，Json格式： {"show_url":"https://或http://打头的商品的展示地址"} ，在支付时，可点击商品名称跳转到该地址
        /// </summary>
        public Goods[] GoodsDetail { get; set; }

        /// <summary>
        /// 公用回传参数，如果请求时传递了该参数，则返回给商户时会回传该参数。
		/// 支付宝只会在异步通知时将该参数原样返回。本参数必须进行UrlEncode之后才可以发送给支付宝
        /// </summary>
        [StringLength(512, ErrorMessage = "公用回传参数最大长度为512位")]
        public string PassbackParams { get; set; }

        /// <summary>
        /// 业务扩展参数，详见业务扩展参数说明 https://docs.open.alipay.com/#kzcs
        /// </summary>
        public ExtendParam ExtendParams { get; set; }

        /// <summary>
        /// 商品主类型：0—虚拟类商品，1—实物类商品（默认
		/// 注：虚拟类商品不支持使用花呗渠道
        /// </summary>
        [Range(0, 1, ErrorMessage = "商品主类型只能为0或1")]
        public int GoodsType { get; set; }

        /// <summary>
        /// 该笔订单允许的最晚付款时间，逾期将关闭交易。
		/// 取值范围：1m～15d。m-分钟，h-小时，d-天，1c-当天（1c-当天的情况下，无论交易何时创建，都在0点关闭）。
		/// 该参数数值不接受小数点， 如 1.5h，可转换为 90m。该参数在请求到支付宝时开始计时。
        /// </summary>
        [StringLength(6, ErrorMessage = "该笔订单允许的最晚付款时间最大长度为6位")]
        public string TimeoutExpress { get; set; }

        /// <summary>
        /// 绝对超时时间，格式为yyyy-MM-dd HH:mm。 
        /// 注：1）以支付宝系统时间为准；2）如果和timeout_express参数同时传入，以time_expire为准。
        /// </summary>
        [StringLength(32, ErrorMessage = "绝对超时时间最大长度为32位")]
        public string TimeExpire { get; set; }

        /// <summary>
        /// 可用渠道，用户只能在指定渠道范围内支付,当有多个渠道时用“,”分隔
		/// 注：与disable_pay_channels互斥 https://docs.open.alipay.com/#qdsm
        /// </summary>
        [StringLength(128, ErrorMessage = "可用渠道最大长度为128位")]
        public string EnablePayChannels { get; set; }

        /// <summary>
        /// 禁用渠道，用户不可用指定渠道支付,当有多个渠道时用“,”分隔
		/// 注：与enable_pay_channels互斥 https://docs.open.alipay.com/#qdsm
        /// </summary>
        [StringLength(128, ErrorMessage = "禁用渠道最大长度为128位")]
        public string DisablePayChannels { get; set; }

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

        /// <summary>
        /// 优惠参数 注：仅与支付宝协商后可用
        /// </summary>
        [StringLength(512, ErrorMessage = "优惠参数最大长度为512位")]
        public string PromoParams { get; set; }

        /// <summary>
        /// 商户门店编号。该参数用于请求参数中以区分各门店，非必传项。
        /// </summary>
        [StringLength(32, ErrorMessage = "商户门店编号最大长度为32位")]
        public string StoreId { get; set; }

        /// <summary>
        /// 添加该参数后在h5支付收银台会出现返回按钮，可用于用户付款中途退出并返回到该参数指定的商户网站地址。
        /// 注：该参数对支付宝钱包标准收银台下的跳转不生效。
        /// </summary>
        [StringLength(400, ErrorMessage = "退出地址最大长度为400位")]
        public string QuitUrl { get; set; }

        /// <summary>
        /// 支付场景 
        /// 条码支付，取值：bar_code
        /// 声波支付，取值：wave_code
        /// </summary>
        [StringLength(32, ErrorMessage = "支付场景最大长度为32位")]
        [Necessary(GatewayTradeType.Barcode, ErrorMessage = "请设置支付场景")]
        public string Scene { get; set; }

        /// <summary>
        /// 支付授权码，25~30开头的长度为16~24位的数字，实际字符串长度以开发者获取的付款码长度为准
        /// </summary>
        [StringLength(32, ErrorMessage = "支付授权码最大长度为32位")]
        [Necessary(GatewayTradeType.Barcode, ErrorMessage = "请设置支付授权码")]
        public string AuthCode { get; set; }

        /// <summary>
        /// 买家的支付宝用户id，如果为空，会从传入了码值信息中获取买家ID
        /// </summary>
        [StringLength(28, ErrorMessage = "买家的支付宝用户id最大长度为28位")]
        public string BuyerId { get; set; }

        /// <summary>
        /// 卖家支付宝用户号,如果该值为空，则默认为商户签约账号对应的支付宝用户ID
        /// </summary>
        [StringLength(28, ErrorMessage = "卖家支付宝用户号最大长度为28位")]
        public string SellerId { get; set; }

        /// <summary>
        /// 参与优惠计算的金额，单位为元，精确到小数点后两位，取值范围[0.01,100000000]。 
        /// 如果该值未传入，但传入了【订单总金额】和【不可打折金额】，则该值默认为【订单总金额】-【不可打折金额】
        /// </summary>
        [Range(0.01, 100000000, ErrorMessage = "订单总金额超出范围")]
        public double? DiscountableAmount { get; set; }

        /// <summary>
        /// 商户操作员编号	
        /// </summary>
        [StringLength(28, ErrorMessage = "商户操作员编号最大长度为28位")]
        public string OperatorId { get; set; }

        /// <summary>
        /// 商户机具终端编号	
        /// </summary>
        [StringLength(32, ErrorMessage = "商户机具终端编号最大长度为32位")]
        public string TerminalId { get; set; }

        /// <summary>
        /// 商户传入业务信息，具体值要和支付宝约定，应用于安全，营销等参数直传场景，格式为json格式	
        /// </summary>
        [StringLength(512, ErrorMessage = "商户传入业务信息最大长度为512位")]
        public string BusinessParams { get; set; }
    }
}
