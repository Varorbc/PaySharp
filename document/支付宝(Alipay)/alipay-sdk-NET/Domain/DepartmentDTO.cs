using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// DepartmentDTO Data Structure.
    /// </summary>
    [Serializable]
    public class DepartmentDTO : AopObject
    {
        /// <summary>
        /// 业务类型KOUBEI_OPERATOR
        /// </summary>
        [XmlElement("biz_type")]
        public string BizType { get; set; }

        /// <summary>
        /// 部门组织id
        /// </summary>
        [XmlElement("dept_id")]
        public string DeptId { get; set; }

        /// <summary>
        /// 组织树部门名称
        /// </summary>
        [XmlElement("dept_name")]
        public string DeptName { get; set; }

        /// <summary>
        /// 组织部门树
        /// </summary>
        [XmlElement("dept_path")]
        public string DeptPath { get; set; }

        /// <summary>
        /// 人员组织场景的部门标签码
        /// </summary>
        [XmlElement("label_code")]
        public string LabelCode { get; set; }

        /// <summary>
        /// 人员组织场景的部门标签名称
        /// </summary>
        [XmlElement("label_name")]
        public string LabelName { get; set; }

        /// <summary>
        /// 上级组织部门id
        /// </summary>
        [XmlElement("parent_dept_id")]
        public string ParentDeptId { get; set; }

        /// <summary>
        /// 门店id，只有叶子节点部门才有shop_id
        /// </summary>
        [XmlElement("shop_id")]
        public string ShopId { get; set; }

        /// <summary>
        /// 组织部门类型(5为非叶子部门，6为叶子部门)
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }
    }
}
