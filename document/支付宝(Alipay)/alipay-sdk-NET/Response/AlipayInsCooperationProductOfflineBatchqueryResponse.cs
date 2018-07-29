using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Aop.Api.Domain;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayInsCooperationProductOfflineBatchqueryResponse.
    /// </summary>
    public class AlipayInsCooperationProductOfflineBatchqueryResponse : AopResponse
    {
        /// <summary>
        /// 返回给机构的线下产品信息列表
        /// </summary>
        [XmlArray("product_list")]
        [XmlArrayItem("ins_offilne_product")]
        public List<InsOffilneProduct> ProductList { get; set; }
    }
}
