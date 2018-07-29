using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiMerchantDepartmentShopsQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiMerchantDepartmentShopsQueryModel : AopObject
    {
        /// <summary>
        /// isv回传的auth_code，通过auth_code校验当前操作人与商户的关系
        /// </summary>
        [XmlElement("auth_code")]
        public string AuthCode { get; set; }

        /// <summary>
        /// 部门id
        /// </summary>
        [XmlElement("dept_id")]
        public string DeptId { get; set; }

        /// <summary>
        /// 判断是否需要加载下属部门的门店列表，当为true是加载当前及其下属部门关联的门店列表，为false时仅加载当前部门id关联的门店列表
        /// </summary>
        [XmlElement("need_sub")]
        public bool NeedSub { get; set; }
    }
}
