using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiMerchantDepartmentShopModifyModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiMerchantDepartmentShopModifyModel : AopObject
    {
        /// <summary>
        /// isv回传的auth_code，通过auth_code校验当前操作人与商户的关系
        /// </summary>
        [XmlElement("auth_code")]
        public string AuthCode { get; set; }

        /// <summary>
        /// 需要调整的部门id
        /// </summary>
        [XmlElement("dept_id")]
        public string DeptId { get; set; }

        /// <summary>
        /// 部门类型，5为非叶子节点部门即商户创建的部门；6为叶子节点部门即门店，门店在业务上被当成是类型为6的部门
        /// </summary>
        [XmlElement("dept_type")]
        public string DeptType { get; set; }

        /// <summary>
        /// 商户调整部门，门店关系时当前部门需要新增的门店列表，包括门店id和门店名称
        /// </summary>
        [XmlArray("shop_list_to_add")]
        [XmlArrayItem("simple_shop_model")]
        public List<SimpleShopModel> ShopListToAdd { get; set; }

        /// <summary>
        /// 商户调整部门，门店关联关系，需要解除关系的门店列表，包括门店id和门店名称
        /// </summary>
        [XmlArray("shop_list_to_remove")]
        [XmlArrayItem("simple_shop_model")]
        public List<SimpleShopModel> ShopListToRemove { get; set; }
    }
}
