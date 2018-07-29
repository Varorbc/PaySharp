using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AssetDeliveryDetail Data Structure.
    /// </summary>
    [Serializable]
    public class AssetDeliveryDetail : AopObject
    {
        /// <summary>
        /// 配送数量
        /// </summary>
        [XmlElement("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// 配送订单ID
        /// </summary>
        [XmlElement("assign_item_id")]
        public string AssignItemId { get; set; }

        /// <summary>
        /// 由供应商自定义的分批反馈批次号，用于保持幂等，此值不传则需要按整批反馈.(由字母,数字,下划线组成)
        /// </summary>
        [XmlElement("batch_no")]
        public string BatchNo { get; set; }

        /// <summary>
        /// 物流单信息
        /// </summary>
        [XmlArray("logistics_infos")]
        [XmlArrayItem("logistics_info")]
        public List<LogisticsInfo> LogisticsInfos { get; set; }
    }
}
