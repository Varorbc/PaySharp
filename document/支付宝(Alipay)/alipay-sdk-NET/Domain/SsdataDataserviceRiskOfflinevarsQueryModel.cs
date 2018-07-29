using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// SsdataDataserviceRiskOfflinevarsQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class SsdataDataserviceRiskOfflinevarsQueryModel : AopObject
    {
        /// <summary>
        /// 查询离线变量的主键
        /// </summary>
        [XmlElement("rowkeys")]
        public string Rowkeys { get; set; }
    }
}
