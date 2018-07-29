using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// SupplierReportDetail Data Structure.
    /// </summary>
    [Serializable]
    public class SupplierReportDetail : AopObject
    {
        /// <summary>
        /// 批次编码
        /// </summary>
        [XmlElement("batch_code")]
        public string BatchCode { get; set; }

        /// <summary>
        /// 过期日期
        /// </summary>
        [XmlElement("expire_date")]
        public string ExpireDate { get; set; }

        /// <summary>
        /// 货品编码
        /// </summary>
        [XmlElement("goods_code")]
        public string GoodsCode { get; set; }

        /// <summary>
        /// 库存类型
        /// </summary>
        [XmlElement("inventory_type")]
        public string InventoryType { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        [XmlElement("price")]
        public string Price { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        [XmlElement("production_date")]
        public string ProductionDate { get; set; }

        /// <summary>
        /// 差异数量,为正整数
        /// </summary>
        [XmlElement("quantity_diff")]
        public long QuantityDiff { get; set; }

        /// <summary>
        /// 盘盈/盘亏(increase/reduce)
        /// </summary>
        [XmlElement("report_type")]
        public string ReportType { get; set; }

        /// <summary>
        /// 供货商盘点单明细id
        /// </summary>
        [XmlElement("supplier_report_detail_id")]
        public string SupplierReportDetailId { get; set; }

        /// <summary>
        /// 供货商盘点单id
        /// </summary>
        [XmlElement("supplier_report_id")]
        public string SupplierReportId { get; set; }
    }
}
