using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayQueryCardModelResult Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayQueryCardModelResult : AopObject
    {
        /// <summary>
        /// 卡余额
        /// </summary>
        [XmlElement("balance")]
        public string Balance { get; set; }

        /// <summary>
        /// 卡公司自定义卡数据
        /// </summary>
        [XmlElement("card_data")]
        public string CardData { get; set; }

        /// <summary>
        /// 卡号。和卡类型一起，唯一确定一张卡。
        /// </summary>
        [XmlElement("card_no")]
        public string CardNo { get; set; }

        /// <summary>
        /// 卡状态
        /// </summary>
        [XmlElement("card_status")]
        public string CardStatus { get; set; }

        /// <summary>
        /// 卡类型。每种虚拟卡都有对应的卡类型，该值由支付宝分配给商户。
        /// </summary>
        [XmlElement("card_type")]
        public string CardType { get; set; }

        /// <summary>
        /// 扩展信息
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        [XmlElement("last_update_time")]
        public string LastUpdateTime { get; set; }

        /// <summary>
        /// 商户卡状态
        /// </summary>
        [XmlElement("status_code")]
        public string StatusCode { get; set; }

        /// <summary>
        /// 商户卡状态信息，与status_code对应，用于描述status_code处于某个状态的原因。
        /// </summary>
        [XmlElement("status_msg")]
        public string StatusMsg { get; set; }

        /// <summary>
        /// 用户授权信息
        /// </summary>
        [XmlElement("user_auth_info")]
        public string UserAuthInfo { get; set; }

        /// <summary>
        /// 蚂蚁统一会员ID
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
