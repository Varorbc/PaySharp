using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenPublicAdvertModifyModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenPublicAdvertModifyModel : AopObject
    {
        /// <summary>
        /// 广告位id
        /// </summary>
        [XmlElement("advert_id")]
        public string AdvertId { get; set; }

        /// <summary>
        /// 广告位轮播内容列表，数量限制：大于1个，小于3个，广告位轮播内容顺序，根据接口传入的顺序排列
        /// </summary>
        [XmlArray("advert_items")]
        [XmlArrayItem("advert_item")]
        public List<AdvertItem> AdvertItems { get; set; }
    }
}
