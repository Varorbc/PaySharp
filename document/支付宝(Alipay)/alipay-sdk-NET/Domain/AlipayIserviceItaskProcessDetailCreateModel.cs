using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayIserviceItaskProcessDetailCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayIserviceItaskProcessDetailCreateModel : AopObject
    {
        /// <summary>
        /// 接口服务端名称
        /// </summary>
        [XmlElement("app_name")]
        public string AppName { get; set; }

        /// <summary>
        /// 附件地址
        /// </summary>
        [XmlElement("attachment")]
        public string Attachment { get; set; }

        /// <summary>
        /// 接口客户端名称
        /// </summary>
        [XmlElement("exapp_name")]
        public string ExappName { get; set; }

        /// <summary>
        /// 外部工单创建人ID
        /// </summary>
        [XmlElement("excreator_id")]
        public string ExcreatorId { get; set; }

        /// <summary>
        /// 外部工单创建人名称
        /// </summary>
        [XmlElement("excreator_name")]
        public string ExcreatorName { get; set; }

        /// <summary>
        /// 外部工单创建人部门ID
        /// </summary>
        [XmlElement("exsystem_department_id")]
        public string ExsystemDepartmentId { get; set; }

        /// <summary>
        /// BU名称（xspace填写对应的租户名称）
        /// </summary>
        [XmlElement("exsystem_department_name")]
        public string ExsystemDepartmentName { get; set; }

        /// <summary>
        /// 外部工单业务扩展字段列表，业务属性信息都放置在此字段。最多10个字段。
        /// </summary>
        [XmlArray("extend_field_infos")]
        [XmlArrayItem("extend_field_info")]
        public List<ExtendFieldInfo> ExtendFieldInfos { get; set; }

        /// <summary>
        /// 工单流程编号
        /// </summary>
        [XmlElement("process_no")]
        public string ProcessNo { get; set; }

        /// <summary>
        /// 工单流程编号_服务端提供给消费端流程模板code
        /// </summary>
        [XmlElement("process_template_code")]
        public string ProcessTemplateCode { get; set; }
    }
}
