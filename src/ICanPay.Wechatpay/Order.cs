using ICanPay.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICanPay.Wechatpay
{
    public class Order : IOrder
    {
        /// <summary>
        /// 商品简单描述，该字段请按照规范传递，具体请见参数规定
        /// </summary>
        [StringLength(128, ErrorMessage = "商品描述最大长度为128位")]
        [Required(ErrorMessage = "请设置商品描述")]
        public string Body { get; set; }

        /// <summary>
        /// 商品详细描述，对于使用单品优惠的商户，改字段必须按照规范上传，详见“单品优惠参数说明”
        /// </summary>
        [StringLength(8000, ErrorMessage = "商品详细描述最大长度为8000位")]
        public string Detail { get; set; }

        /// <summary>
        /// 附加数据，在查询API和支付通知中原样返回，可作为自定义参数使用。
        /// </summary>
        [StringLength(127, ErrorMessage = "附加数据最大长度为127位")]
        public string Attach { get; set; }

        /// <summary>
        /// 标价币种,符合ISO 4217标准的三位字母代码，默认人民币：CNY，详细列表请参见货币类型
        /// </summary>
        [StringLength(16, ErrorMessage = "标价币种最大长度为16位")]
        public string FeeType { get; set; } = "CNY";

        /// <summary>
        /// 商户系统内部订单号，要求32个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一。详见商户订单号
        /// </summary>
        [StringLength(32, ErrorMessage = "商户系统内部订单号最大长度为32位")]
        [Required(ErrorMessage = "请设置商户系统内部订单号")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 终端IP,	APP和网页支付提交用户端ip，Native支付填调用微信支付API的机器IP
        /// </summary>
        [StringLength(16, ErrorMessage = "终端IP最大长度为16位")]
        public string SpbillCreateIp { get; internal set; }

        /// <summary>
        /// 标价金额,订单总金额，单位为元，详见支付金额
        /// </summary>
        [ReName(Name = Constant.TOTAL_FEE)]
        public double Amount
        {
            get => _amount;
            set => _amount = value * 100;
        }
        private double _amount;

        /// <summary>
        /// 订单生成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。其他详见时间规则
        /// </summary>
        public string TimeStart => DateTime.Now.ToString("yyyyMMddHHmmss");

        /// <summary>
        /// 订单失效时间，格式为yyyyMMddHHmmss，如2009年12月27日9点10分10秒表示为20091227091010。其他详见时间规则
        /// 注意：最短失效时间间隔必须大于5分钟
        /// </summary>
        public string TimeExpire { get; set; }

        /// <summary>
        /// 订单优惠标记,使用代金券或立减优惠功能时需要的参数，说明详见代金券或立减优惠
        /// </summary>
        [StringLength(32, ErrorMessage = "订单优惠标记最大长度为32位")]
        public string GoodsTag { get; set; }

        /// <summary>
        /// 商品ID,trade_type=NATIVE时（即扫码支付），此参数必传。此参数为二维码中包含的商品ID，商户自行定义
        /// </summary>
        [StringLength(32, ErrorMessage = "商品ID最大长度为32位")]
        [Necessary(GatewayTradeType.Scan, ErrorMessage = "请设置商品ID")]
        public string ProductId { get; set; }

        /// <summary>
        /// 指定支付方式,上传此参数no_credit--可限制用户不能使用信用卡支付
        /// </summary>
        [StringLength(32, ErrorMessage = "指定支付方式最大长度为32位")]
        public string LimitPay { get; set; }

        /// <summary>
        /// 用户标识
        /// trade_type=JSAPI时（即公众号支付），此参数必传，此参数为微信用户在商户对应appid下的唯一标识。
        /// openid如何获取，可参考【获取openid】。
        /// 企业号请使用【企业号OAuth2.0接口】获取企业号内成员userid，再调用【企业号userid转openid接口】进行转换
        /// </summary>
        [ReName(Name = Constant.OPENID)]
        [Necessary(new GatewayTradeType[] { GatewayTradeType.Public, GatewayTradeType.Applet }, ErrorMessage = "请设置用户标识")]
        public string OpenId { get; set; }

        /// <summary>
        /// 场景信息,该字段用于上报场景信息，目前支持上报实际门店信息。该字段为JSON对象数据，对象格式为{"store_info":{"id": "门店ID","name": "名称","area_code": "编码","address": "地址" }}
        /// </summary>
        [StringLength(256, ErrorMessage = "场景信息最大长度为256位")]
        [Necessary(GatewayTradeType.Wap, ErrorMessage = "请设置场景信息")]
        public string SceneInfo { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        public string TradeType { get; set; }

        /// <summary>
        /// 授权码
        /// 扫码支付授权码，设备读取用户微信中的条码或者二维码信息
        /// （注：用户刷卡条形码规则：18位纯数字，以10、11、12、13、14、15开头）
        /// </summary>
        [StringLength(128, ErrorMessage = "授权码最大长度为128位")]
        [Necessary(GatewayTradeType.Barcode, ErrorMessage = "请设置授权码")]
        public string AuthCode { get; set; }
    }
}
