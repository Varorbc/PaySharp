using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiMerchantDepartmentDeleteModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiMerchantDepartmentDeleteModel : AopObject
    {
        /// <summary>
        /// isv回传的auth_code，通过auth_code校验当前操作人与商户的关系
        /// </summary>
        [XmlElement("auth_code")]
        public string AuthCode { get; set; }

        /// <summary>
        /// 需要被删除的部门id
        /// </summary>
        [XmlElement("dept_id")]
        public string DeptId { get; set; }
    }
}
