using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// KoubeiTradeTicketTicketcodeDelayResponse.
    /// </summary>
    public class KoubeiTradeTicketTicketcodeDelayResponse : AopResponse
    {
        /// <summary>
        /// 该字段用于描述本次返回中的业务属性，现有：BIZ_ALREADY_SUCCESS（幂等业务码）。
        /// </summary>
        [XmlElement("biz_code")]
        public string BizCode { get; set; }

        /// <summary>
        /// 请求id，唯一标识一次请求
        /// </summary>
        [XmlElement("request_id")]
        public string RequestId { get; set; }
    }
}
