using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayInsAutoUserPointQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayInsAutoUserPointQueryModel : AopObject
    {
        /// <summary>
        /// 车险活动类型编码。  攒油活动：SAVE_OIL
        /// </summary>
        [XmlElement("auto_campaign_type")]
        public string AutoCampaignType { get; set; }

        /// <summary>
        /// 蚂蚁统一会员ID
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
