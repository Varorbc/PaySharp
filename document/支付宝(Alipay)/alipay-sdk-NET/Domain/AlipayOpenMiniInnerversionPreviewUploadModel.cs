using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenMiniInnerversionPreviewUploadModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenMiniInnerversionPreviewUploadModel : AopObject
    {
        /// <summary>
        /// 构建参数- JSAPI 权限文件, JSON 字符串
        /// </summary>
        [XmlElement("build_js_permission")]
        public string BuildJsPermission { get; set; }

        /// <summary>
        /// 构建参数-IDE 构建好的包地址
        /// </summary>
        [XmlElement("build_pkg_url")]
        public string BuildPkgUrl { get; set; }

        /// <summary>
        /// 小程序ID
        /// </summary>
        [XmlElement("mini_app_id")]
        public string MiniAppId { get; set; }
    }
}
