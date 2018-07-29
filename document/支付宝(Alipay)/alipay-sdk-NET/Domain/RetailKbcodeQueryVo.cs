using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// RetailKbcodeQueryVo Data Structure.
    /// </summary>
    [Serializable]
    public class RetailKbcodeQueryVo : AopObject
    {
        /// <summary>
        /// 创建口碑码的批次号
        /// </summary>
        [XmlElement("batch_id")]
        public string BatchId { get; set; }

        /// <summary>
        /// 码的物料模板
        /// </summary>
        [XmlElement("code_template")]
        public string CodeTemplate { get; set; }

        /// <summary>
        /// 商户名称，生成码的时候码图片上的提示文案
        /// </summary>
        [XmlElement("code_tip")]
        public string CodeTip { get; set; }

        /// <summary>
        /// 口碑码(不带背景)
        /// </summary>
        [XmlElement("code_url")]
        public string CodeUrl { get; set; }

        /// <summary>
        /// 口碑码创建时间
        /// </summary>
        [XmlElement("create_time")]
        public string CreateTime { get; set; }

        /// <summary>
        /// 口碑码id
        /// </summary>
        [XmlElement("qr_code")]
        public string QrCode { get; set; }

        /// <summary>
        /// 口碑码（带背景）
        /// </summary>
        [XmlElement("resource_url")]
        public string ResourceUrl { get; set; }

        /// <summary>
        /// 促销员信息
        /// </summary>
        [XmlElement("salesman")]
        public string Salesman { get; set; }
    }
}
