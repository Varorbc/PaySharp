using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AuthenticationScene Data Structure.
    /// </summary>
    [Serializable]
    public class AuthenticationScene : AopObject
    {
        /// <summary>
        /// 渠道类型
        /// </summary>
        [XmlElement("access_channel")]
        public string AccessChannel { get; set; }

        /// <summary>
        /// 系统名称
        /// </summary>
        [XmlElement("biz_name")]
        public string BizName { get; set; }

        /// <summary>
        /// 业务产品节点
        /// </summary>
        [XmlElement("biz_prod_node")]
        public string BizProdNode { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        [XmlElement("biz_product")]
        public string BizProduct { get; set; }

        /// <summary>
        /// 场景参数
        /// </summary>
        [XmlElement("scene_params")]
        public string SceneParams { get; set; }
    }
}
