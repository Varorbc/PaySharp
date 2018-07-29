using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayMsaasMediarecogAftsCertIdentifyModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayMsaasMediarecogAftsCertIdentifyModel : AopObject
    {
        /// <summary>
        /// 扩展入参
        /// </summary>
        [XmlElement("ext")]
        public string Ext { get; set; }

        /// <summary>
        /// 高
        /// </summary>
        [XmlElement("h")]
        public long H { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        [XmlElement("plate_number")]
        public string PlateNumber { get; set; }

        /// <summary>
        /// 传入资源URL或djangoid或aftsid
        /// </summary>
        [XmlElement("url")]
        public string Url { get; set; }

        /// <summary>
        /// 蚂蚁统一会员ID
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// 宽
        /// </summary>
        [XmlElement("w")]
        public long W { get; set; }

        /// <summary>
        /// 左上角x
        /// </summary>
        [XmlElement("x")]
        public long X { get; set; }

        /// <summary>
        /// 左上角y
        /// </summary>
        [XmlElement("y")]
        public long Y { get; set; }
    }
}
