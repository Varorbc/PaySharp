using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayInsAutoAutoinsprodEnquriyApplyModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayInsAutoAutoinsprodEnquriyApplyModel : AopObject
    {
        /// <summary>
        /// 代理人身份信息
        /// </summary>
        [XmlElement("agent")]
        public InsPerson Agent { get; set; }

        /// <summary>
        /// 代理人userId
        /// </summary>
        [XmlElement("agent_user_id")]
        public string AgentUserId { get; set; }

        /// <summary>
        /// 投保人身份信息
        /// </summary>
        [XmlElement("applicant")]
        public InsPerson Applicant { get; set; }

        /// <summary>
        /// 车辆信息
        /// </summary>
        [XmlElement("car")]
        public Car Car { get; set; }

        /// <summary>
        /// 车主身份信息
        /// </summary>
        [XmlElement("car_owner")]
        public InsPerson CarOwner { get; set; }

        /// <summary>
        /// 投保城市编码
        /// </summary>
        [XmlElement("city_code")]
        public string CityCode { get; set; }

        /// <summary>
        /// 被保人身份信息
        /// </summary>
        [XmlElement("insured")]
        public InsPerson Insured { get; set; }

        /// <summary>
        /// 外部询价申请业务单号（幂等字段）
        /// </summary>
        [XmlElement("out_biz_no")]
        public string OutBizNo { get; set; }
    }
}
