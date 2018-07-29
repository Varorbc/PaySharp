using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// UserCrowdConditions Data Structure.
    /// </summary>
    [Serializable]
    public class UserCrowdConditions : AopObject
    {
        /// <summary>
        /// 最爱这家店的人
        /// </summary>
        [XmlElement("crowd_group_id")]
        public string CrowdGroupId { get; set; }

        /// <summary>
        /// 用户群组描述
        /// </summary>
        [XmlElement("describe")]
        public string Describe { get; set; }

        /// <summary>
        /// 命中用户规则集合
        /// </summary>
        [XmlArray("hit_crowd_conditons")]
        [XmlArrayItem("condition_item_pattern")]
        public List<ConditionItemPattern> HitCrowdConditons { get; set; }
    }
}
