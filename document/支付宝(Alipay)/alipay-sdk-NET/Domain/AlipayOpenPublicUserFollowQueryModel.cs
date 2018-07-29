using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenPublicUserFollowQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenPublicUserFollowQueryModel : AopObject
    {
        /// <summary>
        /// 支付宝用户id，2088开头的16位长度字符串
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
