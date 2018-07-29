using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// SsdataFindataReportQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class SsdataFindataReportQueryModel : AopObject
    {
        /// <summary>
        /// 商户在调用产品的第一个接口时系统返回的业务流水号
        /// </summary>
        [XmlElement("biz_no")]
        public string BizNo { get; set; }
    }
}
