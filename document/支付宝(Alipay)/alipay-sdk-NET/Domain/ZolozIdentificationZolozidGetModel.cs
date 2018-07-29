using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ZolozIdentificationZolozidGetModel Data Structure.
    /// </summary>
    [Serializable]
    public class ZolozIdentificationZolozidGetModel : AopObject
    {
        /// <summary>
        /// get region
        /// </summary>
        [XmlElement("action")]
        public string Action { get; set; }

        /// <summary>
        /// bizId
        /// </summary>
        [XmlElement("biz_id")]
        public string BizId { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        [XmlElement("extern_params")]
        public string ExternParams { get; set; }

        /// <summary>
        /// json字符串
        /// </summary>
        [XmlElement("zcif_params")]
        public string ZcifParams { get; set; }
    }
}
