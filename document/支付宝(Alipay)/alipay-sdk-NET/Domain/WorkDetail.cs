using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// WorkDetail Data Structure.
    /// </summary>
    [Serializable]
    public class WorkDetail : AopObject
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
        /// 扩展字段，json格式
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 货品编号
        /// </summary>
        [XmlElement("goods_code")]
        public string GoodsCode { get; set; }

        /// <summary>
        /// 库存类型，ZP=正品, CC=残次, JS=机损, XS=箱损, 默认为ZP
        /// </summary>
        [XmlElement("inventory_type")]
        public string InventoryType { get; set; }

        /// <summary>
        /// 价格，单位元，两位小数
        /// </summary>
        [XmlElement("price")]
        public string Price { get; set; }

        /// <summary>
        /// 货品生产日期
        /// </summary>
        [XmlElement("production_date")]
        public string ProductionDate { get; set; }

        /// <summary>
        /// 实际作业数量
        /// </summary>
        [XmlElement("quantity")]
        public long Quantity { get; set; }
    }
}
