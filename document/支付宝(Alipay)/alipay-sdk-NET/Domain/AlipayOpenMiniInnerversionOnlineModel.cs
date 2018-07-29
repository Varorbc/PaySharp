using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenMiniInnerversionOnlineModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenMiniInnerversionOnlineModel : AopObject
    {
        /// <summary>
        /// 下架版本
        /// </summary>
        [XmlElement("app_offline_version")]
        public string AppOfflineVersion { get; set; }

        /// <summary>
        /// 上架版本
        /// </summary>
        [XmlElement("app_online_version")]
        public string AppOnlineVersion { get; set; }

        /// <summary>
        /// 小程序ID
        /// </summary>
        [XmlElement("mini_app_id")]
        public string MiniAppId { get; set; }
    }
}
