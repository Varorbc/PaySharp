using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// OfferObject Data Structure.
    /// </summary>
    [Serializable]
    public class OfferObject : AopObject
    {
        /// <summary>
        /// 服务编码
        /// </summary>
        [XmlElement("app_code")]
        public string AppCode { get; set; }

        /// <summary>
        /// 分类编码
        /// </summary>
        [XmlElement("category_code")]
        public string CategoryCode { get; set; }

        /// <summary>
        /// 城市编码
        /// </summary>
        [XmlElement("city_code")]
        public string CityCode { get; set; }

        /// <summary>
        /// 展台ID，这个是唯一主键，这个最重要，作为我方的source_offer_id存在表里，而且是唯一的
        /// </summary>
        [XmlElement("displayapp_id")]
        public string DisplayappId { get; set; }

        /// <summary>
        /// 展台操作备注
        /// </summary>
        [XmlElement("displayapp_memo")]
        public string DisplayappMemo { get; set; }

        /// <summary>
        /// 展台名称
        /// </summary>
        [XmlElement("displayapp_name")]
        public string DisplayappName { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [XmlElement("displayapp_status")]
        public string DisplayappStatus { get; set; }

        /// <summary>
        /// URL
        /// </summary>
        [XmlElement("displayapp_url")]
        public string DisplayappUrl { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [XmlElement("gmt_create")]
        public string GmtCreate { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [XmlElement("gmt_modified")]
        public string GmtModified { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        [XmlElement("logo_url")]
        public string LogoUrl { get; set; }

        /// <summary>
        /// 实际的URL
        /// </summary>
        [XmlElement("service_url")]
        public string ServiceUrl { get; set; }
    }
}
