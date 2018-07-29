using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiRetailWmsDeliveryorderprocessQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiRetailWmsDeliveryorderprocessQueryModel : AopObject
    {
        /// <summary>
        /// 通知单id
        /// </summary>
        [XmlElement("notice_order_id")]
        public string NoticeOrderId { get; set; }
    }
}
