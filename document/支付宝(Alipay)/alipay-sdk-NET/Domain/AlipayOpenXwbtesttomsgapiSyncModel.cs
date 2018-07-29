using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenXwbtesttomsgapiSyncModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenXwbtesttomsgapiSyncModel : AopObject
    {
        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("xwb")]
        public string Xwb { get; set; }
    }
}
