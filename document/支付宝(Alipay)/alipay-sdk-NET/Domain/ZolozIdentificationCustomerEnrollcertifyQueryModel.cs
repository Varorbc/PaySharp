using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ZolozIdentificationCustomerEnrollcertifyQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class ZolozIdentificationCustomerEnrollcertifyQueryModel : AopObject
    {
        /// <summary>
        /// 业务单据号，用于核对和排查
        /// </summary>
        [XmlElement("biz_id")]
        public string BizId { get; set; }

        /// <summary>
        /// 0：匿名注册  1：匿名认证   2：实名认证
        /// </summary>
        [XmlElement("face_type")]
        public long FaceType { get; set; }

        /// <summary>
        /// zimId，用于查询认证结果
        /// </summary>
        [XmlElement("zim_id")]
        public string ZimId { get; set; }
    }
}
