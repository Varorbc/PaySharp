using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ZhimaCreditEpEntityMonitorUploadModel Data Structure.
    /// </summary>
    [Serializable]
    public class ZhimaCreditEpEntityMonitorUploadModel : AopObject
    {
        /// <summary>
        /// 监控实体列表（实体名，实体代码）
        /// </summary>
        [XmlElement("entity_list")]
        public string EntityList { get; set; }

        /// <summary>
        /// 监控实体类别
        /// </summary>
        [XmlElement("entity_type")]
        public string EntityType { get; set; }

        /// <summary>
        /// 监控方案ID,可空
        /// </summary>
        [XmlElement("solution_id")]
        public string SolutionId { get; set; }

        /// <summary>
        /// 芝麻商户2688 ID
        /// </summary>
        [XmlElement("zhima_pid")]
        public string ZhimaPid { get; set; }
    }
}
