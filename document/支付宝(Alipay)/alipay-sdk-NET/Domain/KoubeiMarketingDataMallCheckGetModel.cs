using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiMarketingDataMallCheckGetModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiMarketingDataMallCheckGetModel : AopObject
    {
        /// <summary>
        /// 安全校验数据内容入参
        /// </summary>
        [XmlArray("check_contents")]
        [XmlArrayItem("data_sec_check_content")]
        public List<DataSecCheckContent> CheckContents { get; set; }

        /// <summary>
        /// 数据源:USER--C端，MERCHANT--B端
        /// </summary>
        [XmlElement("data_source")]
        public string DataSource { get; set; }
    }
}
