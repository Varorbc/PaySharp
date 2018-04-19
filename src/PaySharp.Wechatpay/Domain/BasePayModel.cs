using PaySharp.Core;
using PaySharp.Core.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Wechatpay.Domain
{
    /// <summary>
    /// 支付基础模型
    /// </summary>
    public class BasePayModel
    {
        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; } = Util.GenerateNonceStr();

        /// <summary>
        /// 设备号
        /// 自定义参数，可以为终端设备号(门店号或收银设备ID)，PC网页或公众号内支付可以传"WEB"
        /// </summary>
        [StringLength(32, ErrorMessage = "设备号最大长度为32位")]
        public string DeviceInfo { get; set; }

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
        /// 商户系统内部订单号，要求32个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一。详见商户订单号
        /// </summary>
        [StringLength(32, ErrorMessage = "商户系统内部订单号最大长度为32位")]
        [Required(ErrorMessage = "请设置商户系统内部订单号")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 标价币种,符合ISO 4217标准的三位字母代码，默认人民币：CNY，详细列表请参见货币类型
        /// </summary>
        [ReName(Name = "fee_type")]
        [StringLength(16, ErrorMessage = "标价币种最大长度为16位")]
        public string AmountType { get; set; } = "CNY";

        /// <summary>
        /// 标价金额,订单总金额，单位为分，详见支付金额
        /// </summary>
        [ReName(Name = "total_fee")]
        public int TotalAmount { get; set; }

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
        /// 指定支付方式,上传此参数no_credit--可限制用户不能使用信用卡支付
        /// </summary>
        [StringLength(32, ErrorMessage = "指定支付方式最大长度为32位")]
        public string LimitPay { get; set; }
    }
}
