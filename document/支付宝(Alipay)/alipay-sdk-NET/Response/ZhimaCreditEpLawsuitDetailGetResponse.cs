using System;
using System.Xml.Serialization;
using Aop.Api.Domain;

namespace Aop.Api.Response
{
    /// <summary>
    /// ZhimaCreditEpLawsuitDetailGetResponse.
    /// </summary>
    public class ZhimaCreditEpLawsuitDetailGetResponse : AopResponse
    {
        /// <summary>
        /// 芝麻信用对于每一次请求返回的业务号。后续可以通过此业务号进行对账
        /// </summary>
        [XmlElement("biz_no")]
        public string BizNo { get; set; }

        /// <summary>
        /// 企业涉诉详情
        /// </summary>
        [XmlElement("lawsuit_detail")]
        public EpInfo LawsuitDetail { get; set; }
    }
}
