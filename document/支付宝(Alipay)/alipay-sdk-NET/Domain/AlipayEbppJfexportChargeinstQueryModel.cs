using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayEbppJfexportChargeinstQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayEbppJfexportChargeinstQueryModel : AopObject
    {
        /// <summary>
        /// 业务类型英文简称，固定传JF，表示缴费
        /// </summary>
        [XmlElement("biz_type")]
        public string BizType { get; set; }

        /// <summary>
        /// 拓展字段，json串(key-value对)
        /// </summary>
        [XmlElement("extend_field")]
        public string ExtendField { get; set; }

        /// <summary>
        /// 第几页，从1开始，默认为1
        /// </summary>
        [XmlElement("page")]
        public long Page { get; set; }

        /// <summary>
        /// 是否分页查询，非分页查询时最多返回500条数据。
        /// </summary>
        [XmlElement("page_query")]
        public bool PageQuery { get; set; }

        /// <summary>
        /// 每页展示的行数，默认为10
        /// </summary>
        [XmlElement("page_size")]
        public long PageSize { get; set; }

        /// <summary>
        /// 子业务类型英文简称，ELECTRIC-电费，WATER-水费，GAS-燃气费
        /// </summary>
        [XmlElement("sub_biz_type")]
        public string SubBizType { get; set; }
    }
}
