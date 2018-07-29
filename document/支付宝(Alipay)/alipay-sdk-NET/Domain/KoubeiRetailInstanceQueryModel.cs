using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiRetailInstanceQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiRetailInstanceQueryModel : AopObject
    {
        /// <summary>
        /// 券或者电子DM单（VOUCHER、DM），如果字段为空返回VOUCHER类型
        /// </summary>
        [XmlElement("instance_type")]
        public string InstanceType { get; set; }

        /// <summary>
        /// 当前页码，默认1
        /// </summary>
        [XmlElement("page_num")]
        public long PageNum { get; set; }

        /// <summary>
        /// 一次请求返回的数据量，1~100整数，默认10
        /// </summary>
        [XmlElement("page_size")]
        public long PageSize { get; set; }
    }
}
