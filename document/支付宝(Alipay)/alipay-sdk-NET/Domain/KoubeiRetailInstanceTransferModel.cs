using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiRetailInstanceTransferModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiRetailInstanceTransferModel : AopObject
    {
        /// <summary>
        /// 置顶的券id列表信息，id的顺序指定置顶的券的顺序，如果空表示将原先的id删除。列表数量限制为20
        /// </summary>
        [XmlArray("instance_id_list")]
        [XmlArrayItem("string")]
        public List<string> InstanceIdList { get; set; }

        /// <summary>
        /// 券或者电子DM单（VOUCHER、DM），如果字段为空默认为VOUCHER类型
        /// </summary>
        [XmlElement("instance_type")]
        public string InstanceType { get; set; }
    }
}
