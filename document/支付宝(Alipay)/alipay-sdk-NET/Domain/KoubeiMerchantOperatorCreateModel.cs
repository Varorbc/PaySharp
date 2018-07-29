using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiMerchantOperatorCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiMerchantOperatorCreateModel : AopObject
    {
        /// <summary>
        /// 授权码
        /// </summary>
        [XmlElement("auth_code")]
        public string AuthCode { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        [XmlElement("department_id")]
        public string DepartmentId { get; set; }

        /// <summary>
        /// 折让限额单位
        /// </summary>
        [XmlElement("discount_limit_unit")]
        public string DiscountLimitUnit { get; set; }

        /// <summary>
        /// 折让限额值
        /// </summary>
        [XmlElement("discount_limit_value")]
        public string DiscountLimitValue { get; set; }

        /// <summary>
        /// 免单限额单位
        /// </summary>
        [XmlElement("free_limit_unit")]
        public string FreeLimitUnit { get; set; }

        /// <summary>
        /// 免单限额
        /// </summary>
        [XmlElement("free_limit_value")]
        public string FreeLimitValue { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [XmlElement("gender")]
        public string Gender { get; set; }

        /// <summary>
        /// 操作员绑定的部门类型 5-部门，6-门店
        /// </summary>
        [XmlElement("job_type")]
        public string JobType { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        [XmlElement("login_id")]
        public string LoginId { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [XmlElement("mobile")]
        public string Mobile { get; set; }

        /// <summary>
        /// 操作员名字
        /// </summary>
        [XmlElement("operator_name")]
        public string OperatorName { get; set; }

        /// <summary>
        /// 角色ID, 示例值角色为店长
        /// </summary>
        [XmlElement("role_id")]
        public string RoleId { get; set; }
    }
}
