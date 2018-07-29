using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenDataItemSyncModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenDataItemSyncModel : AopObject
    {
        /// <summary>
        /// 变更事件类型  枚举值  1 展台信息变更  2 首页投放状态变更
        /// </summary>
        [XmlElement("event_type")]
        public string EventType { get; set; }

        /// <summary>
        /// 扩展信息，JSON格式，内容包含可能有:  catagory_code 分类code  area_code 地区code  service_code 服务code  status 状态  audit_time 审核时间  reason 审核反馈  operator 操作人
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 外部修改key  event_type 加 external_id 全局唯一  展台信息变更时填写展台id  投放信息变更时填写投放id
        /// </summary>
        [XmlElement("external_id")]
        public string ExternalId { get; set; }

        /// <summary>
        /// 变更时间
        /// </summary>
        [XmlElement("gmt_modified")]
        public string GmtModified { get; set; }

        /// <summary>
        /// 操作类型  枚举值  ADD 新增  UPDATE 修改  DEL 删除
        /// </summary>
        [XmlElement("operate_type")]
        public string OperateType { get; set; }
    }
}
