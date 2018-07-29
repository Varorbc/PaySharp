using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// RecResultInfo Data Structure.
    /// </summary>
    [Serializable]
    public class RecResultInfo : AopObject
    {
        /// <summary>
        /// 错误码  NO_REC_ITEMS 无推荐服务  NO_ENOUGH_ITEMS 推荐数量不合法
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 推荐ITEM
        /// </summary>
        [XmlArray("items")]
        [XmlArrayItem("rec_item_info")]
        public List<RecItemInfo> Items { get; set; }

        /// <summary>
        /// 错误消息，如果成功则为空
        /// </summary>
        [XmlElement("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 推荐结果
        /// </summary>
        [XmlElement("position_id")]
        public string PositionId { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }
    }
}
