using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// SettleInfo Data Structure.
    /// </summary>
    [Serializable]
    public class SettleInfo : AopObject
    {
        /// <summary>
        /// 结算详细信息，json数组，目前只支持一条。
        /// </summary>
        [XmlArray("settle_detail_infos")]
        [XmlArrayItem("settle_detail_info")]
        public List<SettleDetailInfo> SettleDetailInfos { get; set; }
    }
}
