using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Alipay.Domain
{
    /// <summary>
    /// 条码支付模型
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class BarcodePayModel
    {
        /// <summary>
        /// 商户订单号，64个字符以内、可包含字母、数字、下划线；需保证在商户端不重复
        /// </summary>
        [StringLength(64, ErrorMessage = "商户订单号最大长度为64位")]
        [Required(ErrorMessage = "请设置商户订单号")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 支付场景 
        /// </summary>
        public string Scene => "bar_code";

        /// <summary>
        /// 支付授权码，25~30开头的长度为16~24位的数字，实际字符串长度以开发者获取的付款码长度为准
        /// </summary>
        [StringLength(32, ErrorMessage = "支付授权码最大长度为32位")]
        public string AuthCode { get; set; }

        /// <summary>
        /// 销售产品码，与支付宝签约的产品码名称。 
        /// </summary>
        public string ProductCode => "FACE_TO_FACE_PAYMENT";

        /// <summary>
        /// 订单标题
        /// </summary>
        [StringLength(256, ErrorMessage = "订单标题最大长度为256位")]
        [Required(ErrorMessage = "请设置订单标题")]
        public string Subject { get; set; }

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
        /// 订单总金额，单位为元
        /// </summary>
        [Required(ErrorMessage = "请设置订单总金额")]
        public double TotalAmount { get; set; }

        /// <summary>
        /// 标价币种, total_amount 对应的币种单位。支持英镑：GBP、港币：HKD、美元：USD、新加坡元：SGD、日元：JPY、加拿大元：CAD、澳元：AUD、欧元：EUR、新西兰元：NZD、韩元：KRW、泰铢：THB、瑞士法郎：CHF、瑞典克朗：SEK、丹麦克朗：DKK、挪威克朗：NOK、马来西亚林吉特：MYR、印尼卢比：IDR、菲律宾比索：PHP、毛里求斯卢比：MUR、以色列新谢克尔：ILS、斯里兰卡卢比：LKR、俄罗斯卢布：RUB、阿联酋迪拉姆：AED、捷克克朗：CZK、南非兰特：ZAR、人民币：CNY
        /// </summary>
        [StringLength(8, ErrorMessage = "标价币种最大长度为8位")]
        public string TransCurrency { get; set; }

        /// <summary>
        /// 商户指定的结算币种，支持英镑：GBP、港币：HKD、美元：USD、新加坡元：SGD、日元：JPY、加拿大元：CAD、澳元：AUD、欧元：EUR、新西兰元：NZD、韩元：KRW、泰铢：THB、瑞士法郎：CHF、瑞典克朗：SEK、丹麦克朗：DKK、挪威克朗：NOK、马来西亚林吉特：MYR、印尼卢比：IDR、菲律宾比索：PHP、毛里求斯卢比：MUR、以色列新谢克尔：ILS、斯里兰卡卢比：LKR、俄罗斯卢布：RUB、阿联酋迪拉姆：AED、捷克克朗：CZK、南非兰特：ZAR、人民币：CNY
        /// </summary>
        [StringLength(8, ErrorMessage = "结算币种最大长度为8位")]
        public string SettleCurrency { get; set; }

        /// <summary>
        /// 参与优惠计算的金额，单位为元，精确到小数点后两位，取值范围[0.01,100000000]。 
        /// 如果该值未传入，但传入了【订单总金额】和【不可打折金额】，则该值默认为【订单总金额】-【不可打折金额】
        /// </summary>
        public double DiscountableAmount { get; set; }

        /// <summary>
        /// 订单描述
        /// </summary>
        [StringLength(128, ErrorMessage = "商户订单号最大长度为128位")]
        public string Body { get; set; }

        /// <summary>
        /// 订单包含的商品列表信息
        /// </summary>
        public List<Goods> GoodsDetail { get; set; }

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
        /// 预授权确认模式，授权转交易请求中传入，适用于预授权转交易业务使用，目前只支持PRE_AUTH(预授权产品码) 
        /// COMPLETE：转交易支付完成结束预授权，解冻剩余金额; NOT_COMPLETE：转交易支付完成不结束预授权，不解冻剩余金额
        /// </summary>
        [StringLength(32, ErrorMessage = "预授权确认模式最大长度为32位")]
        public string AuthConfirmMode { get; set; }

        /// <summary>
        /// 商户传入终端设备相关信息，具体值要和支付宝约定
        /// </summary>
        [StringLength(2048, ErrorMessage = "商户传入终端设备相关信息最大长度为2048位")]
        public string TerminalParams { get; set; }
    }
}
