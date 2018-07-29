using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AssetInfoItem Data Structure.
    /// </summary>
    [Serializable]
    public class AssetInfoItem : AopObject
    {
        /// <summary>
        /// 配送或者生产指令id.
        /// </summary>
        [XmlElement("assign_item_id")]
        public string AssignItemId { get; set; }

        /// <summary>
        /// 机具序列号
        /// </summary>
        [XmlElement("sub_type")]
        public string SubType { get; set; }

        /// <summary>
        /// 生产资料, 配送资料
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }

        /// <summary>
        /// 格式按照type约定的类型传入, 约定参见物料平台openAPI文档.
        /// </summary>
        [XmlElement("value")]
        public string Value { get; set; }
    }
}
