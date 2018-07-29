using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Aop.Api.Domain;

namespace Aop.Api.Response
{
    /// <summary>
    /// KoubeiCateringCrowdgroupConditionSetResponse.
    /// </summary>
    public class KoubeiCateringCrowdgroupConditionSetResponse : AopResponse
    {
        /// <summary>
        /// 创建成功返回isv创建的分组规则列表
        /// </summary>
        [XmlArray("condition_model_list")]
        [XmlArrayItem("condition_item_pattern")]
        public List<ConditionItemPattern> ConditionModelList { get; set; }

        /// <summary>
        /// isv创建的用户分组id
        /// </summary>
        [XmlElement("crowd_group_id")]
        public string CrowdGroupId { get; set; }

        /// <summary>
        /// 创建状态: success fail
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }
    }
}
