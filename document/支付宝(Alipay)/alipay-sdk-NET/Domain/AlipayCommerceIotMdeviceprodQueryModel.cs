using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayCommerceIotMdeviceprodQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayCommerceIotMdeviceprodQueryModel : AopObject
    {
        /// <summary>
        /// 设备id（物料系统的id）
        /// </summary>
        [XmlElement("asset_id")]
        public string AssetId { get; set; }
    }
}
