using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOverseasTravelContentCountSyncModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOverseasTravelContentCountSyncModel : AopObject
    {
        /// <summary>
        /// 计数信息列表
        /// </summary>
        [XmlArray("count_infos")]
        [XmlArrayItem("count_info")]
        public List<CountInfo> CountInfos { get; set; }
    }
}
