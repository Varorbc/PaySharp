using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiCateringDishDictionarySyncModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiCateringDishDictionarySyncModel : AopObject
    {
        /// <summary>
        /// 业务字典类型. 定义如下: catetory 分类 ;unit 单位;spec 规格;group 套餐项目组
        /// </summary>
        [XmlElement("biz_type")]
        public string BizType { get; set; }

        /// <summary>
        /// 字典类
        /// </summary>
        [XmlElement("kb_dish_dictionary")]
        public KbdishDictionary KbDishDictionary { get; set; }

        /// <summary>
        /// 同步类型: add 新增;update 修改;stateChange 状态变更;del删除
        /// </summary>
        [XmlElement("syn_type")]
        public string SynType { get; set; }
    }
}
