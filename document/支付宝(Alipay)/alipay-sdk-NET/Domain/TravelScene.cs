using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// TravelScene Data Structure.
    /// </summary>
    [Serializable]
    public class TravelScene : AopObject
    {
        /// <summary>
        /// 出行场景，综合体入参列表
        /// </summary>
        [XmlArray("data_list")]
        [XmlArrayItem("travel_mall_request")]
        public List<TravelMallRequest> DataList { get; set; }
    }
}
