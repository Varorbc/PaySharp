using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayDataDataserviceDeployorderResultSendModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayDataDataserviceDeployorderResultSendModel : AopObject
    {
        /// <summary>
        /// 部署单记录id
        /// </summary>
        [XmlElement("record_id")]
        public string RecordId { get; set; }

        /// <summary>
        /// 处理结果
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }
    }
}
