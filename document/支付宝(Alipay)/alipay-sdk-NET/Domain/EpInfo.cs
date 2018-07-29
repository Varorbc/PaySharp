using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// EpInfo Data Structure.
    /// </summary>
    [Serializable]
    public class EpInfo : AopObject
    {
        /// <summary>
        /// 企业征信元素列表，如一套企业工商照面信息。数据长度不定。
        /// </summary>
        [XmlArray("ep_element_list")]
        [XmlArrayItem("ep_element")]
        public List<EpElement> EpElementList { get; set; }
    }
}
