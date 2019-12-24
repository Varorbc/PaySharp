using System.ComponentModel.DataAnnotations;
using PaySharp.Allinpay.Enum;
using PaySharp.Core;
using PaySharp.Core.Utils;

namespace PaySharp.Allinpay.Domain
{
    /// <summary>
    /// 支付基础模型
    /// </summary>
    public class BasePayModel
    {
        /// <summary>
        /// 交易金额,单位为分
        /// </summary>
        [ReName(Name = "trxamt")]
        public int TotalAmount { get; set; }

        /// <summary>
        /// 商户的交易订单号
        /// </summary>
        [StringLength(32, ErrorMessage = "商户的交易订单号最大长度为32位")]
        [Required(ErrorMessage = "请设置商户的交易订单号")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 交易方式
        /// </summary>
        public PayType PayType { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        [ReName(Name = "randomstr")]
        public string NonceStr { get; } = Util.GenerateNonceStr();

        /// <summary>
        /// 商品名称，为空则以商户名作为商品名称
        /// </summary>
        [StringLength(50, ErrorMessage = "商品描述最大长度为50位")]
        public string Body { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(80, ErrorMessage = "备注最大长度为80位")]
        public string Remark { get; set; }

        /// <summary>
        /// 订单有效时间，以分为单位
        /// </summary>
        public int ValidTime { get; set; } = 5;

        /// <summary>
        /// 支付限制,上传此参数no_credit--可限制用户不能使用信用卡支付
        /// </summary>
        /// <remarks>暂时只对微信支付和支付宝有效,仅支持no_credit</remarks>
        [StringLength(32, ErrorMessage = "指定支付方式最大长度为32位")]
        public string LimitPay { get; set; }

        /// <summary>
        /// 订单优惠标记，用于区分订单是否可以享受优惠，字段内容在微信后台配置券时进行设置，说明详见代金券或立减优惠
        /// </summary>
        /// <remarks>只对微信支付有效W01交易方式不支持</remarks>
        [StringLength(32, ErrorMessage = "订单优惠标记最大长度为32位")]
        public string GoodsTag { get; set; }

        /// <summary>
        /// 优惠信息,Benefitdetail的json字符串
        /// </summary>
        /// <remarks>微信单品优惠 W01交易方式不支持 支付宝智慧门店</remarks>
        public string BenefitDetail { get; set; }

        /// <summary>
        /// 商户门店编号
        /// </summary>
        [ReName(Name = "chnlstoreid")]
        public string ChannelStoreId { get; set; }

        /// <summary>
        /// 门店号
        /// </summary>
        [ReName(Name = "subbranch")]
        public string StoreId { get; set; }

        /// <summary>
        /// 业务扩展参数
        /// </summary>
        public string ExtendParams { get; set; }

        /// <summary>
        /// 商户的终端ip
        /// </summary>
        [ReName(Name = "cusip")]
        [StringLength(16, ErrorMessage = "商户的终端ip最大长度为16位")]
        public string TerminalIP { get; set; }

        /// <summary>
        /// 证件号
        /// </summary>
        [ReName(Name = "idno")]
        [StringLength(32, ErrorMessage = "证件号最大长度为32位")]
        public string IDNumber { get; set; }

        /// <summary>
        /// 付款人真实姓名
        /// </summary>
        [StringLength(32, ErrorMessage = "付款人真实姓名最大长度为32位")]
        public string TrueName { get; set; }

        /// <summary>
        /// 分账信息
        /// </summary>
        [ReName(Name = "asinfo")]
        [StringLength(1024, ErrorMessage = "分账信息最大长度为1024位")]
        public string LedgerInfo { get; set; }

        /// <summary>
        /// 花呗分期数
        /// </summary>
        public int FQNum { get; set; }
    }
}
