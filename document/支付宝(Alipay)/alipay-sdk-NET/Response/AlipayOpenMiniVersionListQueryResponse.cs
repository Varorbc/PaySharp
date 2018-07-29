using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayOpenMiniVersionListQueryResponse.
    /// </summary>
    public class AlipayOpenMiniVersionListQueryResponse : AopResponse
    {
        /// <summary>
        /// 小程序的版本号列表
        /// </summary>
        [XmlArray("app_versions")]
        [XmlArrayItem("string")]
        public List<string> AppVersions { get; set; }
    }
}
