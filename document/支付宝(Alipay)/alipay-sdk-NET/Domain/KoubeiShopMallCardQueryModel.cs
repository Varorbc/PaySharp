using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiShopMallCardQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiShopMallCardQueryModel : AopObject
    {
        /// <summary>
        /// 商圈ID
        /// </summary>
        [XmlElement("mall_id")]
        public string MallId { get; set; }
    }
}
