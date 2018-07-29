using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// RelationInfo Data Structure.
    /// </summary>
    [Serializable]
    public class RelationInfo : AopObject
    {
        /// <summary>
        /// 关系新鲜度，如V_CT_RL30D（最近30天有联系）详细描述见产品文档。
        /// </summary>
        [XmlElement("recency")]
        public string Recency { get; set; }
    }
}
