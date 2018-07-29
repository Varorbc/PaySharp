using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiMerchantOperatorSearchQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiMerchantOperatorSearchQueryModel : AopObject
    {
        /// <summary>
        /// isv回传的auth_code，通过auth_code校验当前操作人与商户的关系
        /// </summary>
        [XmlElement("auth_code")]
        public string AuthCode { get; set; }

        /// <summary>
        /// 操作员所属部门id集合
        /// </summary>
        [XmlArray("dept_ids")]
        [XmlArrayItem("string")]
        public List<string> DeptIds { get; set; }

        /// <summary>
        /// 操作员对应的部门树集合，以“/”分割，最前面的为根部门id，
        /// </summary>
        [XmlArray("dept_paths")]
        [XmlArrayItem("string")]
        public List<string> DeptPaths { get; set; }

        /// <summary>
        /// 当前查询页数
        /// </summary>
        [XmlElement("page_num")]
        public long PageNum { get; set; }

        /// <summary>
        /// 分页大小，每页10条
        /// </summary>
        [XmlElement("page_size")]
        public string PageSize { get; set; }

        /// <summary>
        /// 操作员角色id列表，可以根据角色id列表查询关联的操作员列表
        /// </summary>
        [XmlArray("role_ids")]
        [XmlArrayItem("string")]
        public List<string> RoleIds { get; set; }

        /// <summary>
        /// 模糊查询字段，支持操作员的姓名，别名，手机模糊查询
        /// </summary>
        [XmlElement("search_key")]
        public string SearchKey { get; set; }

        /// <summary>
        /// 操作员的状态列表，T为激活，W为未激活
        /// </summary>
        [XmlArray("status")]
        [XmlArrayItem("string")]
        public List<string> Status { get; set; }

        /// <summary>
        /// 是否查询的是待分配列表，商户的存量数据没有部门关联，设置unassign为true，可以把存量的操作员查出来
        /// </summary>
        [XmlElement("unassign")]
        public bool Unassign { get; set; }
    }
}
