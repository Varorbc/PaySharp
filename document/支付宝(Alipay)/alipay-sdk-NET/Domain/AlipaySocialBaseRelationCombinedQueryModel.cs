using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipaySocialBaseRelationCombinedQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipaySocialBaseRelationCombinedQueryModel : AopObject
    {
        /// <summary>
        /// 最大需要返回的列表值
        /// </summary>
        [XmlElement("limit")]
        public long Limit { get; set; }

        /// <summary>
        /// 关系查询的业务类型编号，此类型由mobilerelation分配，不同的类型对应不同的结果集
        /// </summary>
        [XmlElement("scene_code")]
        public string SceneCode { get; set; }
    }
}
