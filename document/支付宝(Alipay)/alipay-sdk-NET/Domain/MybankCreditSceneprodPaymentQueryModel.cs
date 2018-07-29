using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// MybankCreditSceneprodPaymentQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class MybankCreditSceneprodPaymentQueryModel : AopObject
    {
        /// <summary>
        /// 网商内部代收付申请单编号，外部机构根据此编号查询申请状态。
        /// </summary>
        [XmlElement("in_apply_no")]
        public string InApplyNo { get; set; }
    }
}
