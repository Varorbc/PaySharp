using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Alipay.Domain
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ScanPayModel
    {
        /// <summary>
        /// 商户订单号，64个字符以内、可包含字母、数字、下划线；需保证在商户端不重复
        /// </summary>
        [StringLength(64, ErrorMessage = "商户订单号最大长度为64位")]
        [Required(ErrorMessage = "请设置商户订单号")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 卖家支付宝用户ID。 如果该值为空，则默认为商户签约账号对应的支付宝用户ID
        /// </summary>
        [StringLength(28, ErrorMessage = "卖家支付宝用户ID最大长度为28位")]
        public string SellerId { get; set; }

        /// <summary>
        /// 订单总金额，单位为元
        /// </summary>
        [Required(ErrorMessage = "请设置订单总金额")]
        public double TotalAmount { get; set; }

        /// <summary>
        /// 可打折金额. 参与优惠计算的金额，单位为元，精确到小数点后两位，取值范围[0.01,100000000] 如果该值未传入，但传入了【订单总金额】，【不可打折金额】则该值默认为【订单总金额】-【不可打折金额】
        /// </summary>
        public double DiscountableAmount { get; set; }

        /// <summary>
        /// 订单标题
        /// </summary>
        [StringLength(256, ErrorMessage = "订单标题最大长度为256位")]
        [Required(ErrorMessage = "请设置订单标题")]
        public string Subject { get; set; }

        /// <summary>
        /// 订单包含的商品列表信息
        /// </summary>
        public List<Goods> GoodsDetail { get; set; }

        /// <summary>
        /// 订单描述
        /// </summary>
        [StringLength(128, ErrorMessage = "商户订单号最大长度为128位")]
        public string Body { get; set; }

        /// <summary>
        /// 卖家端自定义的的操作员编号
        /// </summary>
        [StringLength(28, ErrorMessage = "卖家端自定义的的操作员编号最大长度为28位")]
        public string OperatorId { get; set; }

        /// <summary>
        /// 商户门店编号。该参数用于请求参数中以区分各门店，非必传项。
        /// </summary>
        [StringLength(32, ErrorMessage = "商户门店编号最大长度为32位")]
        public string StoreId { get; set; }

        /// <summary>
        /// 禁用渠道，用户不可用指定渠道支付,当有多个渠道时用“,”分隔
        /// 注：与enable_pay_channels互斥 https://docs.open.alipay.com/#qdsm
        /// </summary>
        [StringLength(128, ErrorMessage = "禁用渠道最大长度为128位")]
        public string DisablePayChannels { get; set; }

        /// <summary>
        /// 可用渠道，用户只能在指定渠道范围内支付,当有多个渠道时用“,”分隔
        /// 注：与disable_pay_channels互斥 https://docs.open.alipay.com/#qdsm
        /// </summary>
        [StringLength(128, ErrorMessage = "可用渠道最大长度为128位")]
        public string EnablePayChannels { get; set; }

        /// <summary>
        /// 商户的终端编号
        /// </summary>
        [StringLength(32, ErrorMessage = "终端编号最大长度为32位")]
        public string TerminalId { get; set; }

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
        /// 商户传入业务信息，具体值要和支付宝约定 
        /// 将商户传入信息分发给相应系统，应用于安全，营销等参数直传场景
        /// 格式为json格式
        /// </summary>
        [StringLength(512, ErrorMessage = "商户传入业务信息最大长度为512位")]
        public string BusinessParams { get; set; }
    }
}
