using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// ZhimaCustomerContractInitializeResponse.
    /// </summary>
    public class ZhimaCustomerContractInitializeResponse : AopResponse
    {
        /// <summary>
        /// 电子合约号，后续的电子签名流程需要用到
        /// </summary>
        [XmlElement("contract_no")]
        public string ContractNo { get; set; }
    }
}
