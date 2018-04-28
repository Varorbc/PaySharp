using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Alipay.Domain
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class VoucherDetail
    {
        /// <summary>
        /// 券编号
        /// </summary>
        [StringLength(32, ErrorMessage = "券编号最大长度为32位")]
        [Required(ErrorMessage = "请设置券编号")]
        public string Id { get; set; }

        /// <summary>
        /// 券名称
        /// </summary>
        [StringLength(64, ErrorMessage = "券名称最大长度为64位")]
        [Required(ErrorMessage = "请设置券名称")]
        public string Name { get; set; }

        /// <summary>
        /// 券类型
        /// 当前有三种类型：  ALIPAY_FIX_VOUCHER - 全场代金券  ALIPAY_DISCOUNT_VOUCHER - 折扣券  ALIPAY_ITEM_VOUCHER - 单品优惠  注：不排除将来新增其他类型的可能，商家接入时注意兼容性避免硬编码
        /// </summary>
        [StringLength(32, ErrorMessage = "优惠券类型最大长度为32位")]
        [Required(ErrorMessage = "请设置优惠券类型")]
        public string Type { get; set; }

        /// <summary>
        /// 优惠券面额，它应该会等于商家出资加上其他出资方出资
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// 商家出资（特指发起交易的商家出资金额）
        /// </summary>
        public double? MerchantContribute { get; set; }

        /// <summary>
        /// 其他出资方出资金额，可能是支付宝，可能是品牌商，或者其他方，也可能是他们的一起出资
        /// </summary>
        public double? OtherContribute { get; set; }

        /// <summary>
        /// 优惠券备注信息
        /// </summary>
        [StringLength(256, ErrorMessage = "优惠券备注信息最大长度为256位")]
        public string Memo { get; set; }

        /// <summary>
        /// 券模板编号
        /// </summary>
        [StringLength(64, ErrorMessage = "券模板编号最大长度为64位")]
        public string TemplateId { get; set; }

        /// <summary>
        /// 如果使用的这张券是用户购买的，则该字段代表用户在购买这张券时平台优惠的金额
        /// </summary>
        public double PurchaseAntContribute { get; set; }

        /// <summary>
        /// 如果使用的这张券是用户购买的，则该字段代表用户在购买这张券时用户实际付款的金额
        /// </summary>
        public double PurchaseBuyerContribute { get; set; }

        /// <summary>
        /// 如果使用的这张券是用户购买的，则该字段代表用户在购买这张券时商户优惠的金额
        /// </summary>
        public double PurchaseMerchantContribute { get; set; }
    }
}
