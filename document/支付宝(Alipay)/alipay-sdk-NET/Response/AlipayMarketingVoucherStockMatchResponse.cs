using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayMarketingVoucherStockMatchResponse.
    /// </summary>
    public class AlipayMarketingVoucherStockMatchResponse : AopResponse
    {
        /// <summary>
        /// 已存在券码列表, 已通过创建接口上传的列表
        /// </summary>
        [XmlArray("exist_list")]
        [XmlArrayItem("string")]
        public List<string> ExistList { get; set; }

        /// <summary>
        /// 不存券码列表，还未上传过的券码
        /// </summary>
        [XmlArray("not_exist_list")]
        [XmlArrayItem("string")]
        public List<string> NotExistList { get; set; }
    }
}
