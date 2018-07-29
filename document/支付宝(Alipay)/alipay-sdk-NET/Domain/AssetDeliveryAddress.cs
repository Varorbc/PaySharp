using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AssetDeliveryAddress Data Structure.
    /// </summary>
    [Serializable]
    public class AssetDeliveryAddress : AopObject
    {
        /// <summary>
        /// 详细地址
        /// </summary>
        [XmlElement("address")]
        public string Address { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [XmlElement("city")]
        public string City { get; set; }

        /// <summary>
        /// 收件人
        /// </summary>
        [XmlElement("contact_name")]
        public string ContactName { get; set; }

        /// <summary>
        /// 联系人电话
        /// </summary>
        [XmlElement("contact_phone")]
        public string ContactPhone { get; set; }

        /// <summary>
        /// 区信息
        /// </summary>
        [XmlElement("district")]
        public string District { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        [XmlElement("province")]
        public string Province { get; set; }

        /// <summary>
        /// 仓库id
        /// </summary>
        [XmlElement("warehouse_id")]
        public string WarehouseId { get; set; }

        /// <summary>
        /// 供应商的仓库名称
        /// </summary>
        [XmlElement("warehouse_name")]
        public string WarehouseName { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        [XmlElement("zip_code")]
        public string ZipCode { get; set; }
    }
}
