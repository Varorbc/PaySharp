using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenPublicPayeeBindCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenPublicPayeeBindCreateModel : AopObject
    {
        /// <summary>
        /// 收款账号，需要绑定的收款支付宝账号，跟pid不要同时传
        /// </summary>
        [XmlElement("login_id")]
        public string LoginId { get; set; }

        /// <summary>
        /// 支付宝用户id，2088开头的16位长度字符串，跟login_id不要同时传
        /// </summary>
        [XmlElement("pid")]
        public string Pid { get; set; }
    }
}
