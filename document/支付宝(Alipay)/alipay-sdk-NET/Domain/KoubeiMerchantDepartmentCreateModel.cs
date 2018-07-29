using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiMerchantDepartmentCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiMerchantDepartmentCreateModel : AopObject
    {
        /// <summary>
        /// isv回传的auth_code，通过auth_code校验当前操作人与商户的关系
        /// </summary>
        [XmlElement("auth_code")]
        public string AuthCode { get; set; }

        /// <summary>
        /// 员工管理场景下的商户部门名称，根目录为商户名称，下属部门由商户自己创建，例如可以创建下属部门为“华东大区”
        /// </summary>
        [XmlElement("dept_name")]
        public string DeptName { get; set; }

        /// <summary>
        /// 组织部门标签，现在有PROCESSING_ROOM, DELIVER_CENTRE, CENTRAL_KITCHEN三种
        /// </summary>
        [XmlElement("label_code")]
        public string LabelCode { get; set; }

        /// <summary>
        /// 当前需要创建部门的上级部门id
        /// </summary>
        [XmlElement("parent_dept_id")]
        public string ParentDeptId { get; set; }
    }
}
