using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayEbppIndustryBizinfoApplyModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayEbppIndustryBizinfoApplyModel : AopObject
    {
        /// <summary>
        /// 业务能力码，标识业务场景
        /// </summary>
        [XmlElement("ability_code")]
        public string AbilityCode { get; set; }

        /// <summary>
        /// 业务账户号，例如水费单号，手机号，电费号，信用卡卡号。没有唯一性要求。
        /// </summary>
        [XmlElement("bill_key")]
        public string BillKey { get; set; }

        /// <summary>
        /// 业务机构简称
        /// </summary>
        [XmlElement("biz_inst")]
        public string BizInst { get; set; }

        /// <summary>
        /// 业务类型，公服业务：IND
        /// </summary>
        [XmlElement("biz_type")]
        public string BizType { get; set; }

        /// <summary>
        /// 外部申请流水号，支持幂等
        /// </summary>
        [XmlElement("out_apply_no")]
        public string OutApplyNo { get; set; }

        /// <summary>
        /// 请求上下文，json格式
        /// </summary>
        [XmlElement("request_context")]
        public string RequestContext { get; set; }
    }
}
