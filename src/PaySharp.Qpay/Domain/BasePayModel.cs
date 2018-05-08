using PaySharp.Core;
using PaySharp.Core.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Qpay.Domain
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
        /// 调用接口提交的终端设备号
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
        /// 附加数据，在查询API和支付通知中原样返回，可作为自定义参数使用。
        /// </summary>
        [StringLength(128, ErrorMessage = "附加数据最大长度为128位")]
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
        /// 商户订单总金额，单位为分，只能为整数，详见交易金额
        /// </summary>
        [ReName(Name = "total_fee")]
        public int TotalAmount { get; set; }

        /// <summary>
        /// 订单生成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。其他详见时间规则
        /// </summary>
        public string TimeStart => DateTime.Now.ToString("yyyyMMddHHmmss");

        /// <summary>
        /// 订单失效时间，格式为yyyyMMddHHmmss，如2009年12月27日9点10分10秒表示为20091227091010。其他详见时间规则
        /// </summary>
        public string TimeExpire { get; set; }

        /// <summary>
        /// QQ钱包活动标识
        /// 指定本单参与某个QQ钱包活动或活动档位的标识，包含两个标识：
        /// sale_tag --- 不同活动的匹配标志
        /// level_tag --- 同一活动不同优惠档位的标志，可不填。
        /// 格式如下（本字段参与签名）：promotion_tag=level_tag=xxx&sale_tag=xxx
        /// </summary>
        [StringLength(128, ErrorMessage = "QQ钱包活动标识最大长度为128位")]
        public string PromotionTag { get; set; }

        /// <summary>
        /// 支付方式限制,可以针对当前的交易，限制用户的支付方式，如：仅允许使用余额，或者是禁止使用信用卡。详情见支付方式限制
        /// </summary>
        [StringLength(32, ErrorMessage = "指定支付方式最大长度为32位")]
        public string LimitPay { get; set; }

        /// <summary>
        /// 代扣签约序列号
        /// 商户侧记录的用户代扣协议序列号，支付中开通代扣必传
        /// </summary>
        [StringLength(64, ErrorMessage = "代扣签约序列号最大长度为64位")]
        public string ContractCode { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        public string TradeType { get; protected set; }

        /// <summary>
        /// 用户IP
        /// </summary>
        [Required(ErrorMessage = "请设置用户IP")]
        [StringLength(16, ErrorMessage = "用户IP最大长度为16位")]
        public string SpbillCreateIp { get; set; } = HttpUtil.RemoteIpAddress;
    }
}
