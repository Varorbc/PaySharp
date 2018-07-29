using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipaySecurityRiskPolicyRdsQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipaySecurityRiskPolicyRdsQueryModel : AopObject
    {
        /// <summary>
        /// 参数名称：RDS采集的行为数据；非唯一；参数作用：RDS系统通过行为数据做人机识别；如何获取：客户端集成RDS的SDK后自动会获取到该数据。
        /// </summary>
        [XmlElement("rds_params")]
        public string RdsParams { get; set; }
    }
}
