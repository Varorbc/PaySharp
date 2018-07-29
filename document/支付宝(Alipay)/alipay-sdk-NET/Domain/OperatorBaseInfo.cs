using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// OperatorBaseInfo Data Structure.
    /// </summary>
    [Serializable]
    public class OperatorBaseInfo : AopObject
    {
        /// <summary>
        /// 操作员所属部门id
        /// </summary>
        [XmlElement("dept_id")]
        public string DeptId { get; set; }

        /// <summary>
        /// 操作员所属部门的部门树
        /// </summary>
        [XmlElement("dept_path")]
        public string DeptPath { get; set; }

        /// <summary>
        /// 操作员联系手机
        /// </summary>
        [XmlElement("mobile")]
        public string Mobile { get; set; }

        /// <summary>
        /// 操作员别名
        /// </summary>
        [XmlElement("nick_name")]
        public string NickName { get; set; }

        /// <summary>
        /// 操作员id
        /// </summary>
        [XmlElement("operator_id")]
        public string OperatorId { get; set; }

        /// <summary>
        /// 操作员名称
        /// </summary>
        [XmlElement("operator_name")]
        public string OperatorName { get; set; }

        /// <summary>
        /// 操作员类型，只区分收银员和非收银员  收银员为“RESTRICTED_CASHIER”，非收银员为“STANDARD_NORMAL”
        /// </summary>
        [XmlElement("operator_type")]
        public string OperatorType { get; set; }

        /// <summary>
        /// 描述当前操作员角色类型，CASHIER为收银员，SHOPKEEPER为店长，只有系统角色才有role_code
        /// </summary>
        [XmlElement("role_code")]
        public string RoleCode { get; set; }

        /// <summary>
        /// 操作员所属角色id
        /// </summary>
        [XmlElement("role_id")]
        public string RoleId { get; set; }

        /// <summary>
        /// 员工管理里的角色
        /// </summary>
        [XmlElement("role_name")]
        public string RoleName { get; set; }

        /// <summary>
        /// 操作员状态值，T为激活，W为未激活
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }
    }
}
