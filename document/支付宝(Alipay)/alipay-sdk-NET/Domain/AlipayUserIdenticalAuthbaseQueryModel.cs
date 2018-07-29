using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayUserIdenticalAuthbaseQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayUserIdenticalAuthbaseQueryModel : AopObject
    {
        /// <summary>
        /// 需要校验的userId，该参数需要用作请求路由
        /// </summary>
        [XmlElement("base_user_id")]
        public string BaseUserId { get; set; }

        /// <summary>
        /// 另一个需要校验的用户的支付宝账户ID
        /// </summary>
        [XmlElement("comparator_user_id")]
        public string ComparatorUserId { get; set; }
    }
}
