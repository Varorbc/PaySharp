using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiTradeTicketTicketcodeSendModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiTradeTicketTicketcodeSendModel : AopObject
    {
        /// <summary>
        /// 需要发送的码列表，其中code表示串码码值，num表示码的可核销份数
        /// </summary>
        [XmlArray("isv_ma_list")]
        [XmlArrayItem("kb_isv_ma_code")]
        public List<KbIsvMaCode> IsvMaList { get; set; }

        /// <summary>
        /// 口碑订单号
        /// </summary>
        [XmlElement("order_no")]
        public string OrderNo { get; set; }

        /// <summary>
        /// 请求id，唯一标识一次请求
        /// </summary>
        [XmlElement("request_id")]
        public string RequestId { get; set; }

        /// <summary>
        /// 口碑商品发货单号
        /// </summary>
        [XmlElement("send_order_no")]
        public string SendOrderNo { get; set; }

        /// <summary>
        /// 口碑发码通知透传码商，码商需要跟发码通知获取到的参数一致
        /// </summary>
        [XmlElement("send_token")]
        public string SendToken { get; set; }
    }
}
