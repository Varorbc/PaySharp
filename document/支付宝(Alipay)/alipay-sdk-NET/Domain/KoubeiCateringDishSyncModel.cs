using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiCateringDishSyncModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiCateringDishSyncModel : AopObject
    {
        /// <summary>
        /// dish：操作菜品模型 ;sku:操作关联sku
        /// </summary>
        [XmlElement("biz_type")]
        public string BizType { get; set; }

        /// <summary>
        /// 口碑菜品模型
        /// </summary>
        [XmlElement("kb_dish_info")]
        public KbdishInfo KbDishInfo { get; set; }

        /// <summary>
        /// 同步类型: add 新增;update 修改;stateChange 状态变更,del 删除
        /// </summary>
        [XmlElement("syn_type")]
        public string SynType { get; set; }
    }
}
