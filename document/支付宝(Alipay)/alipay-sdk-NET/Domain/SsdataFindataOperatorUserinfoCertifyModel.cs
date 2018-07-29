using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// SsdataFindataOperatorUserinfoCertifyModel Data Structure.
    /// </summary>
    [Serializable]
    public class SsdataFindataOperatorUserinfoCertifyModel : AopObject
    {
        /// <summary>
        /// 业务流水号，提交用户信息时系统返回
        /// </summary>
        [XmlElement("biz_no")]
        public string BizNo { get; set; }

        /// <summary>
        /// 用户运营商登录信息
        /// </summary>
        [XmlElement("form_map")]
        public LoginForm FormMap { get; set; }
    }
}
