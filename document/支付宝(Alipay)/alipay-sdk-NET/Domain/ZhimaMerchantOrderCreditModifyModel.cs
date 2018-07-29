using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ZhimaMerchantOrderCreditModifyModel Data Structure.
    /// </summary>
    [Serializable]
    public class ZhimaMerchantOrderCreditModifyModel : AopObject
    {
        /// <summary>
        /// 外部订单号, 用于定位需要修改的订单
        /// </summary>
        [XmlElement("out_order_no")]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 逾期时间，不为空时将修改当前订单的逾期时间，入参不得早于系统当前时间
        /// </summary>
        [XmlElement("overdue_time")]
        public string OverdueTime { get; set; }

        /// <summary>
        /// 芝麻订单号，用于定位要修改的订单
        /// </summary>
        [XmlElement("zm_order_no")]
        public string ZmOrderNo { get; set; }
    }
}
