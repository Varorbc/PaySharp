using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// SsdataFindataQxUserinfoUploadModel Data Structure.
    /// </summary>
    [Serializable]
    public class SsdataFindataQxUserinfoUploadModel : AopObject
    {
        /// <summary>
        /// 扩展信息
        /// </summary>
        [XmlElement("ext_params")]
        public string ExtParams { get; set; }

        /// <summary>
        /// C端用户身份证号码
        /// </summary>
        [XmlElement("id_card_no")]
        public string IdCardNo { get; set; }

        /// <summary>
        /// 商户业务流水号，有商户的系统生成的商户业务唯一标识，如果不传，则有上数系统生成一个32位的商户业务流水号并返回
        /// </summary>
        [XmlElement("org_biz_no")]
        public string OrgBizNo { get; set; }

        /// <summary>
        /// C端用户手机号码
        /// </summary>
        [XmlElement("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// C端用户姓名
        /// </summary>
        [XmlElement("user_name")]
        public string UserName { get; set; }
    }
}
