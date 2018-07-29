using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// PosOrderKey Data Structure.
    /// </summary>
    [Serializable]
    public class PosOrderKey : AopObject
    {
        /// <summary>
        /// pos设备序列号
        /// </summary>
        [XmlElement("dv_sn")]
        public string DvSn { get; set; }

        /// <summary>
        /// 商户pid
        /// </summary>
        [XmlElement("merchant_id")]
        public string MerchantId { get; set; }

        /// <summary>
        /// 订单版本号
        /// </summary>
        [XmlElement("order_version")]
        public long OrderVersion { get; set; }

        /// <summary>
        /// pos本地的订单号,同一个商户下唯一标识一笔订单的编号。
        /// </summary>
        [XmlElement("out_biz_no")]
        public string OutBizNo { get; set; }
    }
}
