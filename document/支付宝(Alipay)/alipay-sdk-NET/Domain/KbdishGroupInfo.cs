using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KbdishGroupInfo Data Structure.
    /// </summary>
    [Serializable]
    public class KbdishGroupInfo : AopObject
    {
        /// <summary>
        /// 操作员
        /// </summary>
        [XmlElement("create_user")]
        public string CreateUser { get; set; }

        /// <summary>
        /// 套餐组明细
        /// </summary>
        [XmlArray("detail_list")]
        [XmlArrayItem("kbdish_group_detail_info")]
        public List<KbdishGroupDetailInfo> DetailList { get; set; }

        /// <summary>
        /// 组id
        /// </summary>
        [XmlElement("group_id")]
        public string GroupId { get; set; }

        /// <summary>
        /// 组名称
        /// </summary>
        [XmlElement("group_name")]
        public string GroupName { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("group_rule")]
        public string GroupRule { get; set; }

        /// <summary>
        /// 版本号 就是一个数据操作的时间戳
        /// </summary>
        [XmlElement("group_version")]
        public string GroupVersion { get; set; }

        /// <summary>
        /// 商户id
        /// </summary>
        [XmlElement("merchant_id")]
        public string MerchantId { get; set; }

        /// <summary>
        /// open 启动 stop 停用
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 份数限制
        /// </summary>
        [XmlElement("unit_count_limit")]
        public string UnitCountLimit { get; set; }

        /// <summary>
        /// 修改操作小二
        /// </summary>
        [XmlElement("update_user")]
        public string UpdateUser { get; set; }
    }
}
