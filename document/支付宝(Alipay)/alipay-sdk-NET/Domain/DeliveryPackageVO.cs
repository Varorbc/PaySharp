using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// DeliveryPackageVO Data Structure.
    /// </summary>
    [Serializable]
    public class DeliveryPackageVO : AopObject
    {
        /// <summary>
        /// 通知单id
        /// </summary>
        [XmlElement("delivery_order_code")]
        public string DeliveryOrderCode { get; set; }

        /// <summary>
        /// 菜鸟单号
        /// </summary>
        [XmlElement("delivery_order_id")]
        public string DeliveryOrderId { get; set; }

        /// <summary>
        /// 包裹明细
        /// </summary>
        [XmlArray("delivery_package_detail_list")]
        [XmlArrayItem("delivery_package_detail")]
        public List<DeliveryPackageDetail> DeliveryPackageDetailList { get; set; }

        /// <summary>
        /// 货运单号
        /// </summary>
        [XmlElement("express_code")]
        public string ExpressCode { get; set; }

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
        /// 物流公司编码
        /// </summary>
        [XmlElement("logistics_code")]
        public string LogisticsCode { get; set; }

        /// <summary>
        /// 包裹编码
        /// </summary>
        [XmlElement("package_code")]
        public string PackageCode { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        [XmlElement("warehouse_code")]
        public string WarehouseCode { get; set; }

        /// <summary>
        /// 作业id
        /// </summary>
        [XmlElement("work_order_id")]
        public string WorkOrderId { get; set; }
    }
}
