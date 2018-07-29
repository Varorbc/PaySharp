using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiRetailWmsBatchinventoryQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiRetailWmsBatchinventoryQueryModel : AopObject
    {
        /// <summary>
        /// 货品编码列表
        /// </summary>
        [XmlArray("goods_code_list")]
        [XmlArrayItem("string")]
        public List<string> GoodsCodeList { get; set; }

        /// <summary>
        /// 货品类型，ZP("正品"),CC("残次"),JS("机损"), XS("箱损"),ZT("在途库存")
        /// </summary>
        [XmlElement("inventory_type")]
        public string InventoryType { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        [XmlElement("warehouse_code")]
        public string WarehouseCode { get; set; }
    }
}
