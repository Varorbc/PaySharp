using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Alipay.Domain
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Goods
    {
        /// <summary>
        /// 商品的编号
        /// </summary>
        [JsonProperty("goods_id")]
        [StringLength(32, ErrorMessage = "商品的编号最大长度为32位")]
        [Required(ErrorMessage = "请设置商品的编号")]
        public string Id { get; set; }

        /// <summary>
        /// 支付宝定义的统一商品编号
        /// </summary>
        [StringLength(32, ErrorMessage = "商品的编号最大长度为32位")]
        public string AlipayGoodsId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [JsonProperty("goods_name")]
        [StringLength(256, ErrorMessage = "商品名称最大长度为256位")]
        [Required(ErrorMessage = "请设置商品名称")]
        public string Name { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        [Required(ErrorMessage = "请设置商品数量")]
        public int Quantity { get; set; }

        /// <summary>
        /// 商品单价，单位为元
        /// </summary>
        [Required(ErrorMessage = "请设置商品单价")]
        public double Price { get; set; }

        /// <summary>
        /// 商品类目
        /// </summary>
        [JsonProperty("goods_category")]
        [StringLength(24, ErrorMessage = "商品类目最大长度为24位")]
        public string Category { get; set; }

        /// <summary>
        /// 商品描述信息
        /// </summary>
        [StringLength(1000, ErrorMessage = "商品描述信息最大长度为1000位")]
        public string Body { get; set; }

        /// <summary>
        /// 商品的展示地址
        /// </summary>
        [StringLength(400, ErrorMessage = "商品的展示地址最大长度为400位")]
        public string ShowUrl { get; set; }
    }
}
