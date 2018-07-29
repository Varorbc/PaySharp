using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayEcoEntertainmentOrderUploadModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayEcoEntertainmentOrderUploadModel : AopObject
    {
        /// <summary>
        /// 数娱充值ISV订单回流模型
        /// </summary>
        [XmlElement("entertainment_order_info")]
        public EntertainmentOrderInfo EntertainmentOrderInfo { get; set; }
    }
}
