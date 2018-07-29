using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiMarketingDataSceneMemberpointsGetModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiMarketingDataSceneMemberpointsGetModel : AopObject
    {
        /// <summary>
        /// 会员积分变化场景业务参数
        /// </summary>
        [XmlElement("biz_info")]
        public MemberPointsScene BizInfo { get; set; }

        /// <summary>
        /// 扩展信息
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 代表了一次请求，作为业务幂等性控制
        /// </summary>
        [XmlElement("out_request_no")]
        public string OutRequestNo { get; set; }

        /// <summary>
        /// 场景类型
        /// </summary>
        [XmlElement("scene_type")]
        public string SceneType { get; set; }

        /// <summary>
        /// 支付宝用户的userId
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
