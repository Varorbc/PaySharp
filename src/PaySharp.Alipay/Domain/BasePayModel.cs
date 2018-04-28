using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Alipay.Domain
{
    /// <summary>
    /// 支付基础模型
    /// 目前仅适用于App,Web,Wap
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class BasePayModel
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="productCode">销售产品码</param>
        public BasePayModel(string productCode)
        {
            ProductCode = productCode;
        }

        /// <summary>
        /// 商户订单号，64个字符以内、可包含字母、数字、下划线；需保证在商户端不重复
        /// </summary>
        [StringLength(64, ErrorMessage = "商户订单号最大长度为64位")]
        [Required(ErrorMessage = "请设置商户订单号")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 销售产品码，与支付宝签约的产品码名称。 
        /// </summary>
        public string ProductCode { get; private set; }

        /// <summary>
        /// 订单总金额，单位为元
        /// </summary>
        [Required(ErrorMessage = "请设置订单总金额")]
        public double TotalAmount { get; set; }

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
        /// 业务扩展参数，详见业务扩展参数说明 https://docs.open.alipay.com/#kzcs
        /// </summary>
        public ExtendParam ExtendParams { get; set; }

        /// <summary>
        /// 该笔订单允许的最晚付款时间，逾期将关闭交易。
        /// 取值范围：1m～15d。m-分钟，h-小时，d-天，1c-当天（1c-当天的情况下，无论交易何时创建，都在0点关闭）。
        /// 该参数数值不接受小数点， 如 1.5h，可转换为 90m。该参数在请求到支付宝时开始计时。
        /// </summary>
        [StringLength(6, ErrorMessage = "该笔订单允许的最晚付款时间最大长度为6位")]
        public string TimeoutExpress { get; set; }

        /// <summary>
        /// 公用回传参数，如果请求时传递了该参数，则返回给商户时会回传该参数。
        /// 支付宝只会在异步通知时将该参数原样返回。本参数必须进行UrlEncode之后才可以发送给支付宝
        /// </summary>
        [StringLength(512, ErrorMessage = "公用回传参数最大长度为512位")]
        public string PassbackParams { get; set; }

        /// <summary>
        /// 商品主类型：0—虚拟类商品，1—实物类商品（默认
        /// 注：虚拟类商品不支持使用花呗渠道
        /// </summary>
        [Range(0, 1, ErrorMessage = "商品主类型只能为0或1")]
        public int GoodsType { get; set; }

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
        /// 外部指定买家，详见外部用户ExtUserInfo参数说明 https://docs.open.alipay.com/#wbsh
        /// </summary>
        public ExtUserInfo ExtUserInfo { get; set; }
    }
}
