using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// OpusCreateResponse Data Structure.
    /// </summary>
    [Serializable]
    public class OpusCreateResponse : AopObject
    {
        /// <summary>
        /// 作品外部id
        /// </summary>
        [XmlElement("external_opus_id")]
        public string ExternalOpusId { get; set; }

        /// <summary>
        /// 作品id
        /// </summary>
        [XmlElement("opus_id")]
        public string OpusId { get; set; }
    }
}
