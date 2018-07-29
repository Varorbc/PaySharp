using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiCateringDishGroupSyncModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiCateringDishGroupSyncModel : AopObject
    {
        /// <summary>
        /// 口碑菜品套餐项目组
        /// </summary>
        [XmlElement("kb_dish_group")]
        public KbdishGroupInfo KbDishGroup { get; set; }

        /// <summary>
        /// 同步类型: add 新增;update 修改;stateChange 状态变更,del 删除
        /// </summary>
        [XmlElement("syn_type")]
        public string SynType { get; set; }
    }
}
