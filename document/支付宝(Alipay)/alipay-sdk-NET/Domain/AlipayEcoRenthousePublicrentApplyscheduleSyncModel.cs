using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayEcoRenthousePublicrentApplyscheduleSyncModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayEcoRenthousePublicrentApplyscheduleSyncModel : AopObject
    {
        /// <summary>
        /// 申请单进度列表
        /// </summary>
        [XmlArray("apply_schedule_list")]
        [XmlArrayItem("eco_apply_schedule")]
        public List<EcoApplySchedule> ApplyScheduleList { get; set; }

        /// <summary>
        /// 证件号-身份证号
        /// </summary>
        [XmlElement("cert_no")]
        public string CertNo { get; set; }

        /// <summary>
        /// 租客用户Id
        /// </summary>
        [XmlElement("rent_id")]
        public string RentId { get; set; }
    }
}
