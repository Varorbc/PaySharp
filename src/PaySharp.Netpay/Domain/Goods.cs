using PaySharp.Core;

namespace PaySharp.Netpay.Domain
{
    /// <summary>
    /// 商品模型
    /// </summary>
    public class Goods
    {
        /// <summary>
        /// 折扣
        /// </summary>
        public long Discount { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        [ReName(Name = "goodsId")]
        public string Id { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [ReName(Name = "goodsName")]
        public string Name { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public long Quantity { get; set; }

        /// <summary>
        /// 商品单价（分）
        /// </summary>
        public long Price { get; set; }

        /// <summary>
        /// 商品分类
        /// </summary>
        [ReName(Name = "goodsCategory")]
        public string Category { get; set; }

        /// <summary>
        /// 商品说明
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 子商户号
        /// </summary>
        [ReName(Name = "subMerchantId")]
        public string SubMchId { get; set; }

        /// <summary>
        /// 商户子订单号
        /// </summary>
        [ReName(Name = "merOrderId")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 子商户商品总额
        /// </summary>
        [ReName(Name = "subOrderAmount")]
        public int TotalAmount { get; set; }
    }
}
