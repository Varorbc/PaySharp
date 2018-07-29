using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// SmartAutomatAssociate Data Structure.
    /// </summary>
    [Serializable]
    public class SmartAutomatAssociate : AopObject
    {
        /// <summary>
        /// 合作伙伴类型  DISTRIBUTORS:渠道商
        /// </summary>
        [XmlElement("associate_type")]
        public string AssociateType { get; set; }

        /// <summary>
        /// 合作伙伴的支付宝账号ID
        /// </summary>
        [XmlElement("associate_user_id")]
        public string AssociateUserId { get; set; }
    }
}
