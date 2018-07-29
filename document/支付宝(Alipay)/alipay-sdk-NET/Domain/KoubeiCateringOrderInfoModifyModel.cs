using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiCateringOrderInfoModifyModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiCateringOrderInfoModifyModel : AopObject
    {
        /// <summary>
        /// 触发订单更新的操作类型，比如:  加菜：ADD_DISH；  减菜：SUBSTRACT_DISH；  转台：SWITCH_TABLE；  菜状态变迁：DISH_STATUS_CHANGE  订单信息更新(比如服务费等)：ORDER_MODIFY  其他：OTHER
        /// </summary>
        [XmlElement("action")]
        public string Action { get; set; }

        /// <summary>
        /// 订单最新菜明细列表
        /// </summary>
        [XmlArray("dish_details")]
        [XmlArrayItem("kb_pos_order_dish_detail")]
        public List<KbPosOrderDishDetail> DishDetails { get; set; }

        /// <summary>
        /// 扩展信息，json对象格式，key和value都为字符串
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [XmlElement("memo")]
        public string Memo { get; set; }

        /// <summary>
        /// 其他杂费,以元为单位,精确到分
        /// </summary>
        [XmlElement("other_amount")]
        public string OtherAmount { get; set; }

        /// <summary>
        /// 打包费,以元为单位,精确到分
        /// </summary>
        [XmlElement("packing_amount")]
        public string PackingAmount { get; set; }

        /// <summary>
        /// 用餐人数
        /// </summary>
        [XmlElement("people_num")]
        public long PeopleNum { get; set; }

        /// <summary>
        /// pos业务订单外部主键信息
        /// </summary>
        [XmlElement("pos_order_key")]
        public PosOrderKey PosOrderKey { get; set; }

        /// <summary>
        /// 服务费,以元为单位,精确到分
        /// </summary>
        [XmlElement("service_amount")]
        public string ServiceAmount { get; set; }

        /// <summary>
        /// 取餐号码,示例: 桌号:04,令牌:13,取餐号  :5100,配送 :2018012912312312321( 比如饿了么订单号)
        /// </summary>
        [XmlElement("take_no")]
        public string TakeNo { get; set; }
    }
}
