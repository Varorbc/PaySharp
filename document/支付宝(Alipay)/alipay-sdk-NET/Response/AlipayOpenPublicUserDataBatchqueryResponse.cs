using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Aop.Api.Domain;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayOpenPublicUserDataBatchqueryResponse.
    /// </summary>
    public class AlipayOpenPublicUserDataBatchqueryResponse : AopResponse
    {
        /// <summary>
        /// 用户分析数据
        /// </summary>
        [XmlArray("data_list")]
        [XmlArrayItem("user_analysis_data")]
        public List<UserAnalysisData> DataList { get; set; }
    }
}
