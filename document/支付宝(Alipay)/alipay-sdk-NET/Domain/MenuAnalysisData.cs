using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// MenuAnalysisData Data Structure.
    /// </summary>
    [Serializable]
    public class MenuAnalysisData : AopObject
    {
        /// <summary>
        /// 人均点击次数
        /// </summary>
        [XmlElement("avg_click_user_cnt")]
        public string AvgClickUserCnt { get; set; }

        /// <summary>
        /// 菜单点击次数
        /// </summary>
        [XmlElement("click_cnt")]
        public long ClickCnt { get; set; }

        /// <summary>
        /// 菜单点击人数
        /// </summary>
        [XmlElement("click_user_cnt")]
        public long ClickUserCnt { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        [XmlElement("date")]
        public string Date { get; set; }

        /// <summary>
        /// 菜单类型 ，iconDefault ：图标菜单、default：文字菜单
        /// </summary>
        [XmlElement("menu_type")]
        public string MenuType { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 子菜单名称，文字菜单才有
        /// </summary>
        [XmlElement("sub_name")]
        public string SubName { get; set; }
    }
}
