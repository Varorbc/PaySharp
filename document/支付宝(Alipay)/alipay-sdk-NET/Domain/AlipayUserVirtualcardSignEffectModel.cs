using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayUserVirtualcardSignEffectModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayUserVirtualcardSignEffectModel : AopObject
    {
        /// <summary>
        /// hex格式表示的虚拟卡数据，卡数据将在虚拟卡二维码中透传。
        /// </summary>
        [XmlElement("card_data")]
        public string CardData { get; set; }

        /// <summary>
        /// 商户定义的卡号，card_type+card_no要控制唯一性
        /// </summary>
        [XmlElement("card_no")]
        public string CardNo { get; set; }

        /// <summary>
        /// 卡类型，由支付宝指定。目前每个商户都有自己的卡类型，一家商户还可能有多个卡类型
        /// </summary>
        [XmlElement("card_type")]
        public string CardType { get; set; }

        /// <summary>
        /// 表示虚拟卡是否可用
        /// </summary>
        [XmlElement("disabled")]
        public string Disabled { get; set; }

        /// <summary>
        /// 当虚拟卡不可用时，提示用户不可用原因
        /// </summary>
        [XmlElement("disabled_tips")]
        public string DisabledTips { get; set; }

        /// <summary>
        /// 卡不可用时引导用户的链接
        /// </summary>
        [XmlElement("disabled_url")]
        public string DisabledUrl { get; set; }

        /// <summary>
        /// json格式字符串，存放扩展信息。
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 支付宝用户id
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
