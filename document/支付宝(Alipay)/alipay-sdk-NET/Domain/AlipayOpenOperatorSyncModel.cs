using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenOperatorSyncModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenOperatorSyncModel : AopObject
    {
        /// <summary>
        /// 主账号的userId
        /// </summary>
        [XmlElement("master_user_id")]
        public string MasterUserId { get; set; }

        /// <summary>
        /// 产品code，FINCLOUD=金融云，CSC=云客服
        /// </summary>
        [XmlElement("product_code")]
        public string ProductCode { get; set; }
    }
}
