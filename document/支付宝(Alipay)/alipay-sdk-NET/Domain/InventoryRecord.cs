using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// InventoryRecord Data Structure.
    /// </summary>
    [Serializable]
    public class InventoryRecord : AopObject
    {
        /// <summary>
        /// 可用库存变更之后
        /// </summary>
        [XmlElement("after_modify_lock_quantity")]
        public long AfterModifyLockQuantity { get; set; }

        /// <summary>
        /// 可用库存变更之后
        /// </summary>
        [XmlElement("after_modify_quantity")]
        public long AfterModifyQuantity { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        [XmlElement("batch_code")]
        public string BatchCode { get; set; }

        /// <summary>
        /// 占用库存变更之前
        /// </summary>
        [XmlElement("before_modify_lock_quantity")]
        public string BeforeModifyLockQuantity { get; set; }

        /// <summary>
        /// 可用库存变更之前
        /// </summary>
        [XmlElement("before_modify_quantity")]
        public long BeforeModifyQuantity { get; set; }

        /// <summary>
        /// 占用库存
        /// </summary>
        [XmlElement("diff_lock_quantity")]
        public long DiffLockQuantity { get; set; }

        /// <summary>
        /// 可用库存变化量
        /// </summary>
        [XmlElement("diff_quantity")]
        public long DiffQuantity { get; set; }

        /// <summary>
        /// 过期日期
        /// </summary>
        [XmlElement("expire_date")]
        public string ExpireDate { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [XmlElement("gmt_create")]
        public string GmtCreate { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [XmlElement("gmt_modified")]
        public string GmtModified { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        [XmlElement("goods_code")]
        public string GoodsCode { get; set; }

        /// <summary>
        /// 库存类型（ZP=正品, CC=残次,JS=机损, XS= 箱损, ZT=在途库存）
        /// </summary>
        [XmlElement("inventory_type")]
        public string InventoryType { get; set; }

        /// <summary>
        /// 操作类型（INBOUND＝入库  OUTBOUND＝出库）
        /// </summary>
        [XmlElement("operate_type")]
        public string OperateType { get; set; }

        /// <summary>
        /// 外部订单号
        /// </summary>
        [XmlElement("out_biz_id")]
        public string OutBizId { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        [XmlElement("product_date")]
        public string ProductDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        [XmlElement("warehouse_code")]
        public string WarehouseCode { get; set; }
    }
}
