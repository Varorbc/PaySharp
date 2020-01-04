using System;
using System.ComponentModel.DataAnnotations;
using PaySharp.Core;

namespace PaySharp.Netpay.Domain
{
    public class UnifiedPayModel : BaseModel
    {
        /// <summary>
        /// 商品信息
        /// </summary>
        public Goods Goods { get; set; }

        /// <summary>
        /// 商户附加数据
        /// </summary>
        [StringLength(255, ErrorMessage = "商户附加数据最大长度为64位")]
        public string AttachedData { get; set; }

        /// <summary>
        /// 订单过期时间
        /// </summary>
        public string ExpireTime { get; set; } = DateTime.Now.AddMinutes(30).ToString("yyyy-MM-dd HH:mm:ss");

        /// <summary>
        /// 商品标记，用于优惠活动
        /// </summary>
        [StringLength(32, ErrorMessage = "商品标记最大长度为32位")]
        public string GoodsTag { get; set; }

        /// <summary>
        /// 商品交易单号
        /// 跟goods字段二选一，商品信息通过goods.add接口提前上送
        /// </summary>
        public string GoodsTradeNo { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
        [ReName(Name = "orderDesc")]
        [StringLength(255, ErrorMessage = "商品描述最大长度为255位")]
        public string Body { get; set; }

        /// <summary>
        /// 订单原始金额，单位分，用于记录前端系统打折前的金额
        /// </summary>
        public int OriginalAmount { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// 支付总金额,单位为分
        /// </summary>
        /// <remarks>
        /// 若<see cref="DivisionFlag"/>为true，则：totalAmount = subOrders字段中的所有totalAmount值之和
        /// 加上platformAmount值 =  goods中的所有subOrderAmount值之和。
        /// </remarks>
        public int TotalAmount { get; set; }

        /// <summary>
        /// 分账标记
        /// 暂时只支持微信（WXPay.jsPay）、支付宝（trade.jsPay）支付 和 银联云闪付（uac.appOrder）
        /// 若为true，则goods字段和subOrders字段不能同时为空；且secureTransaction字段上送false或不上送。
        /// </summary>
        public bool DivisionFlag { get; set; }

        /// <summary>
        /// 平台商户分账金额
        /// </summary>
        /// <remarks>若分账标记传，则分账金额必传</remarks>
        public int? PlatformAmount { get; set; }

        /// <summary>
        /// 在传分账标记的情况下，若传子商户号，子商户分账金额必传，即ubOrders每个元素的mid和totalAmount非空 且 mid不超过20个。
        /// 分账方案subOrders里子商户分账总额+platformAmount要与支付总额totalAmount相等
        /// </summary>
        public SubOrders SubOrders { get; set; }

        /// <summary>
        /// 交易类型
        /// 微信必传:APP
        /// </summary>
        public string TradeType { get; set; }

        /// <summary>
        /// 商户用户号
        /// </summary>
        [ReName(Name = "merchantUserId")]
        [StringLength(32, ErrorMessage = "商户用户号最大长度为32位")]
        public string MchUserId { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [StringLength(11, ErrorMessage = "手机号最大长度为11位")]
        public string Mobile { get; set; }

        /// <summary>
        /// 标识是否是担保交易
        /// 若上送为true，则交易的金额将会被暂缓结算。
        /// 调用担保完成接口后，完成部分金额会在t+1日结算给商户，剩余部分金额退还用户。
        /// 调用担保撤销接口，则全部资金退还给用户。
        /// 30天后 没有主动调用担保完成 且 没有主动调用担保撤销的交易 将会自动按撤销处理。
        /// </summary>
        public bool SecureTransaction { get; set; }

        /// <summary>
        /// 是否需要限制信用卡支付
        /// </summary>
        public bool LimitCreditCard { get; set; }
    }
}
