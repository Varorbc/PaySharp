using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenMiniVersionUploadModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenMiniVersionUploadModel : AopObject
    {
        /// <summary>
        /// 小程序版本号，版本号必须满足 x.y.z, 且均为数字
        /// </summary>
        [XmlElement("app_version")]
        public string AppVersion { get; set; }

        /// <summary>
        /// 模板的配置参数
        /// </summary>
        [XmlElement("ext")]
        public string Ext { get; set; }

        /// <summary>
        /// 模板id
        /// </summary>
        [XmlElement("template_id")]
        public string TemplateId { get; set; }

        /// <summary>
        /// 模板版本号，版本号必须满足 x.y.z, 且均为数字
        /// </summary>
        [XmlElement("template_version")]
        public string TemplateVersion { get; set; }
    }
}
