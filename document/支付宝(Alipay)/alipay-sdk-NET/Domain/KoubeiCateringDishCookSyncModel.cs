using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiCateringDishCookSyncModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiCateringDishCookSyncModel : AopObject
    {
        /// <summary>
        /// cook：操作菜谱信息 ; shop:全量覆盖门店; detail;操作菜谱明细以及价格
        /// </summary>
        [XmlElement("biz_type")]
        public string BizType { get; set; }

        /// <summary>
        /// 口碑菜谱
        /// </summary>
        [XmlElement("kb_dish_cook")]
        public KbdishCookInfo KbDishCook { get; set; }

        /// <summary>
        /// 同步类型: add 新增;update 修改;stateChange 状态变更,del 删除
        /// </summary>
        [XmlElement("syn_type")]
        public string SynType { get; set; }
    }
}
