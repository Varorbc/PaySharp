using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayUserAddressQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayUserAddressQueryModel : AopObject
    {
        /// <summary>
        /// 用户地址唯一ID。通过调用小程序开放api(my.chooseAddress)获取。
        /// </summary>
        [XmlElement("address_id")]
        public string AddressId { get; set; }
    }
}
