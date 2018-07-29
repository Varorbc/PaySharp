using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// InboundOrderLine Data Structure.
    /// </summary>
    [Serializable]
    public class InboundOrderLine : AopObject
    {
        /// <summary>
        /// 批次编号
        /// </summary>
        [XmlElement("batch_code")]
        public string BatchCode { get; set; }

        /// <summary>
        /// 货品过期日期
        /// </summary>
        [XmlElement("expire_date")]
        public string ExpireDate { get; set; }

        /// <summary>
        /// 货品编码
        /// </summary>
        [XmlElement("goods_code")]
        public string GoodsCode { get; set; }

        /// <summary>
        /// ZP("正品"),CC("残次"), JS("机损"),XS("箱损"),ZT("在途库存");
        /// </summary>
        [XmlElement("inventory_type")]
        public string InventoryType { get; set; }

        /// <summary>
        /// 计划入库量
        /// </summary>
        [XmlElement("plan_quantity")]
        public long PlanQuantity { get; set; }

        /// <summary>
        /// 价格(单位元，保留2为小数)
        /// </summary>
        [XmlElement("price")]
        public string Price { get; set; }

        /// <summary>
        /// 货品生产日期
        /// </summary>
        [XmlElement("product_date")]
        public string ProductDate { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }
    }
}
