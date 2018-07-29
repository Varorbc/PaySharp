using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ZhimaCustomerContractInitializeModel Data Structure.
    /// </summary>
    [Serializable]
    public class ZhimaCustomerContractInitializeModel : AopObject
    {
        /// <summary>
        /// 合约内容，必须是PDF文件流，BASE64编码
        /// </summary>
        [XmlElement("contract_file")]
        public string ContractFile { get; set; }

        /// <summary>
        /// 合约名称，会展示给签约方
        /// </summary>
        [XmlElement("contract_name")]
        public string ContractName { get; set; }

        /// <summary>
        /// 芝麻认证产品码，示例值为真实的产品码
        /// </summary>
        [XmlElement("product_code")]
        public string ProductCode { get; set; }
    }
}
