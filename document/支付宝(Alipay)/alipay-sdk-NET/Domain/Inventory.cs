using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// Inventory Data Structure.
    /// </summary>
    [Serializable]
    public class Inventory : AopObject
    {
        /// <summary>
        /// 批次编号
        /// </summary>
        [XmlElement("batch_code")]
        public string BatchCode { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        [XmlElement("expire_date")]
        public string ExpireDate { get; set; }

        /// <summary>
        /// 扩展字段，json格式
        /// </summary>
        [XmlElement("extend_props")]
        public string ExtendProps { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [XmlElement("gmt_create")]
        public string GmtCreate { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        [XmlElement("gmt_modified")]
        public string GmtModified { get; set; }

        /// <summary>
        /// 货品编码
        /// </summary>
        [XmlElement("goods_code")]
        public string GoodsCode { get; set; }

        /// <summary>
        /// 货品类型：ZP("正品"), CC("残次"), JS("机损"),  XS("箱损"),ZT("在途库存")
        /// </summary>
        [XmlElement("inventory_type")]
        public string InventoryType { get; set; }

        /// <summary>
        /// 锁定数量
        /// </summary>
        [XmlElement("lock_quantity")]
        public long LockQuantity { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        [XmlElement("product_date")]
        public string ProductDate { get; set; }

        /// <summary>
        /// 可用数量
        /// </summary>
        [XmlElement("quantity")]
        public long Quantity { get; set; }

        /// <summary>
        /// 实际数量
        /// </summary>
        [XmlElement("real_quantity")]
        public long RealQuantity { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        [XmlElement("warehouse_code")]
        public string WarehouseCode { get; set; }
    }
}
