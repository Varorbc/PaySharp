using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiRetailWmsWarehouseQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiRetailWmsWarehouseQueryModel : AopObject
    {
        /// <summary>
        /// 城市编码，国标码，与归属人ID查询配合使用
        /// </summary>
        [XmlElement("city_code")]
        public string CityCode { get; set; }

        /// <summary>
        /// 操作上下文
        /// </summary>
        [XmlElement("operate_context")]
        public OperateContext OperateContext { get; set; }

        /// <summary>
        /// 仓库的归属人类型，SUPPLIER供货商的仓库/PARTNER商户的仓库
        /// </summary>
        [XmlElement("own_type")]
        public string OwnType { get; set; }

        /// <summary>
        /// 仓库的归属人ID、与仓库ID选择一个作为查询条件
        /// </summary>
        [XmlElement("owner_id")]
        public string OwnerId { get; set; }

        /// <summary>
        /// 页码，分页参数，与归属人ID查询配合使用
        /// </summary>
        [XmlElement("page_no")]
        public long PageNo { get; set; }

        /// <summary>
        /// 每页大小，分页参数，与归属人ID查询配合使用
        /// </summary>
        [XmlElement("page_size")]
        public long PageSize { get; set; }

        /// <summary>
        /// 仓库编码、与归属人ID选择一个作为查询条件
        /// </summary>
        [XmlElement("warehouse_code")]
        public string WarehouseCode { get; set; }
    }
}
