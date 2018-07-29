using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// LawsuitPersonRecord Data Structure.
    /// </summary>
    [Serializable]
    public class LawsuitPersonRecord : AopObject
    {
        /// <summary>
        /// 曝光台列表
        /// </summary>
        [XmlArray("bgt_list")]
        [XmlArrayItem("ep_info")]
        public List<EpInfo> BgtList { get; set; }

        /// <summary>
        /// 裁判文书列表
        /// </summary>
        [XmlArray("cpws_list")]
        [XmlArrayItem("ep_info")]
        public List<EpInfo> CpwsList { get; set; }

        /// <summary>
        /// 失信公告列表
        /// </summary>
        [XmlArray("sxgg_list")]
        [XmlArrayItem("ep_info")]
        public List<EpInfo> SxggList { get; set; }

        /// <summary>
        /// 执行公告列表
        /// </summary>
        [XmlArray("zxgg_list")]
        [XmlArrayItem("ep_info")]
        public List<EpInfo> ZxggList { get; set; }
    }
}
