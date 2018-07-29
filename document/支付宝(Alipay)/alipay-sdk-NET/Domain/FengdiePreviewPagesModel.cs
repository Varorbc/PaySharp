using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// FengdiePreviewPagesModel Data Structure.
    /// </summary>
    [Serializable]
    public class FengdiePreviewPagesModel : AopObject
    {
        /// <summary>
        /// 站点页面别名
        /// </summary>
        [XmlElement("alias")]
        public string Alias { get; set; }

        /// <summary>
        /// 页面预览地址
        /// </summary>
        [XmlElement("url")]
        public string Url { get; set; }
    }
}
