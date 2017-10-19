using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ICanPay.Alipay
{
    public class Goods
    {
        /// <summary>
        /// 商品的编号
        /// </summary>
        [JsonProperty(PropertyName = Constant.GOODS_ID)]
        [StringLength(32, ErrorMessage = "商品的编号最大长度为32位")]
        [Required(ErrorMessage = "请设置商品的编号")]
        public string Id { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [JsonProperty(PropertyName = Constant.GOODS_NAME)]
        [StringLength(256, ErrorMessage = "商品名称最大长度为256位")]
        [Required(ErrorMessage = "请设置商品名称")]
        public string Name { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        [JsonProperty(PropertyName = Constant.QUANTITY)]
        [Required(ErrorMessage = "请设置商品数量")]
        public int Quantity { get; set; }

        /// <summary>
        /// 商品单价，单位为元
        /// </summary>
        [JsonProperty(PropertyName = Constant.PRICE)]
        [Required(ErrorMessage = "请设置商品单价")]
        [Range(0.01, 100000000, ErrorMessage = "金额超出范围")]
        public double Price { get; set; }

        /// <summary>
        /// 商品类目
        /// </summary>
        [JsonProperty(PropertyName = Constant.GOODS_CATEGORY)]
        [StringLength(24, ErrorMessage = "商品类目最大长度为24位")]
        public string GoodsCategory { get; set; }

        /// <summary>
        /// 商品描述信息
        /// </summary>
        [JsonProperty(PropertyName = Constant.BODY)]
        [StringLength(1000, ErrorMessage = "商品描述信息最大长度为1000位")]
        public string Body { get; set; }

        /// <summary>
        /// 商品的展示地址
        /// </summary>
        [JsonProperty(PropertyName = Constant.SHOW_URL)]
        [StringLength(400, ErrorMessage = "商品的展示地址最大长度为400位")]
        public string ShowUrl { get; set; }
    }
}
