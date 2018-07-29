using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// InsSellerActivity Data Structure.
    /// </summary>
    [Serializable]
    public class InsSellerActivity : AopObject
    {
        /// <summary>
        /// 关于签约的附加业务信息
        /// </summary>
        [XmlElement("biz_data")]
        public string BizData { get; set; }

        /// <summary>
        /// 签约时间
        /// </summary>
        [XmlElement("join_time")]
        public string JoinTime { get; set; }

        /// <summary>
        /// 状态：1:加入 2:退出 3:清退
        /// </summary>
        [XmlElement("status")]
        public long Status { get; set; }
    }
}
