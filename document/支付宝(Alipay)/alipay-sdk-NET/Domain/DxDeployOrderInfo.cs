using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// DxDeployOrderInfo Data Structure.
    /// </summary>
    [Serializable]
    public class DxDeployOrderInfo : AopObject
    {
        /// <summary>
        /// 决策服务自定义名字空间字段
        /// </summary>
        [XmlElement("biz_ns")]
        public string BizNs { get; set; }

        /// <summary>
        /// 部署事件类型,枚举值如下:  ONLINE,OFFLINE,UPDATE,VERIFY
        /// </summary>
        [XmlElement("deploy_event_type")]
        public string DeployEventType { get; set; }

        /// <summary>
        /// 部署对象类型，共有4个类型:DECISION_RULE(决策规则),DECISION_ROUTER(决策分流规则),DECISION_ROUTER_PERCENT(决策策略分流百分比),DATA_SOURCE(数据源)
        /// </summary>
        [XmlElement("deploy_object_type")]
        public string DeployObjectType { get; set; }

        /// <summary>
        /// 部署单内容
        /// </summary>
        [XmlElement("deploy_payload")]
        public string DeployPayload { get; set; }

        /// <summary>
        /// 部署单业务创建时间
        /// </summary>
        [XmlElement("gmt_biz_create")]
        public string GmtBizCreate { get; set; }

        /// <summary>
        /// 部署的分组名
        /// </summary>
        [XmlElement("group")]
        public string Group { get; set; }

        /// <summary>
        /// 重试的记录id
        /// </summary>
        [XmlElement("pre_record_id")]
        public string PreRecordId { get; set; }

        /// <summary>
        /// 记录id
        /// </summary>
        [XmlElement("record_id")]
        public string RecordId { get; set; }

        /// <summary>
        /// 是否为重试部署单
        /// </summary>
        [XmlElement("retry")]
        public bool Retry { get; set; }
    }
}
