using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiShopMallMemberIdentifyModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiShopMallMemberIdentifyModel : AopObject
    {
        /// <summary>
        /// 商圈ID
        /// </summary>
        [XmlElement("mall_id")]
        public string MallId { get; set; }

        /// <summary>
        /// 蚂蚁统一会员ID
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
