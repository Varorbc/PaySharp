using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// FaceSearchAnonymousUserInfo Data Structure.
    /// </summary>
    [Serializable]
    public class FaceSearchAnonymousUserInfo : AopObject
    {
        /// <summary>
        /// 商户标识
        /// </summary>
        [XmlElement("merchantid")]
        public string Merchantid { get; set; }

        /// <summary>
        /// 商户uid
        /// </summary>
        [XmlElement("merchantuid")]
        public string Merchantuid { get; set; }
    }
}
