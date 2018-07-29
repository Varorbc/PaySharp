using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KbdishTabInfo Data Structure.
    /// </summary>
    [Serializable]
    public class KbdishTabInfo : AopObject
    {
        /// <summary>
        /// 餐台所属餐区的id
        /// </summary>
        [XmlElement("area_id")]
        public string AreaId { get; set; }

        /// <summary>
        /// 餐台创建人
        /// </summary>
        [XmlElement("create_user")]
        public string CreateUser { get; set; }

        /// <summary>
        /// 餐台服务费
        /// </summary>
        [XmlElement("fee_price")]
        public string FeePrice { get; set; }

        /// <summary>
        /// 餐台座位人数
        /// </summary>
        [XmlElement("seat_count")]
        public string SeatCount { get; set; }

        /// <summary>
        /// 餐台id
        /// </summary>
        [XmlElement("tab_id")]
        public string TabId { get; set; }

        /// <summary>
        /// 餐台名称
        /// </summary>
        [XmlElement("tab_name")]
        public string TabName { get; set; }

        /// <summary>
        /// 餐台序号
        /// </summary>
        [XmlElement("tab_sort")]
        public string TabSort { get; set; }

        /// <summary>
        /// 餐台状态 empty:空闲 hold:站位  clean:清扫
        /// </summary>
        [XmlElement("tab_tstatus")]
        public string TabTstatus { get; set; }

        /// <summary>
        /// 餐区修改人
        /// </summary>
        [XmlElement("update_user")]
        public string UpdateUser { get; set; }
    }
}
