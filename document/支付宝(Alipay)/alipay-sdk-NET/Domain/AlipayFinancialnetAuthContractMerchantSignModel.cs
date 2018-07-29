using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayFinancialnetAuthContractMerchantSignModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayFinancialnetAuthContractMerchantSignModel : AopObject
    {
        /// <summary>
        /// 商家银行账号
        /// </summary>
        [XmlElement("account_no")]
        public string AccountNo { get; set; }

        /// <summary>
        /// json串格式的扩展字段
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 费率模型
        /// </summary>
        [XmlElement("fee_value")]
        public FeeValue FeeValue { get; set; }

        /// <summary>
        /// 机构ID
        /// </summary>
        [XmlElement("inst_id")]
        public string InstId { get; set; }

        /// <summary>
        /// 场景码
        /// </summary>
        [XmlElement("scene_code")]
        public string SceneCode { get; set; }

        /// <summary>
        /// 蚂蚁统一会员ID
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// 生效失效策略模型
        /// </summary>
        [XmlElement("valid_strategy")]
        public ValidStrategy ValidStrategy { get; set; }
    }
}
