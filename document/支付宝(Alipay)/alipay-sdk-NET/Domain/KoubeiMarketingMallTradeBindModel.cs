using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiMarketingMallTradeBindModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiMarketingMallTradeBindModel : AopObject
    {
        /// <summary>
        /// 用户的授权动作：auth授权，unAuth取消授权
        /// </summary>
        [XmlElement("action")]
        public string Action { get; set; }

        /// <summary>
        /// 蚂蚁统一会员ID
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
