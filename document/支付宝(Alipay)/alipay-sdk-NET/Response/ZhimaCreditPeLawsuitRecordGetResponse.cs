using System;
using System.Xml.Serialization;
using Aop.Api.Domain;

namespace Aop.Api.Response
{
    /// <summary>
    /// ZhimaCreditPeLawsuitRecordGetResponse.
    /// </summary>
    public class ZhimaCreditPeLawsuitRecordGetResponse : AopResponse
    {
        /// <summary>
        /// 芝麻信用对于每一次请求返回的业务号。后续可以通过此业务号进行对账
        /// </summary>
        [XmlElement("biz_no")]
        public string BizNo { get; set; }

        /// <summary>
        /// 个人涉诉记录
        /// </summary>
        [XmlElement("lawsuit_person_record")]
        public LawsuitPersonRecord LawsuitPersonRecord { get; set; }
    }
}
