using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// SmartAutomatScene Data Structure.
    /// </summary>
    [Serializable]
    public class SmartAutomatScene : AopObject
    {
        /// <summary>
        /// 自助售货机一级场景
        /// </summary>
        [XmlElement("level_1")]
        public string Level1 { get; set; }

        /// <summary>
        /// 自助售货机二级场景
        /// </summary>
        [XmlElement("level_2")]
        public string Level2 { get; set; }
    }
}
