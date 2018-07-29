using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOverseasTravelContentCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOverseasTravelContentCreateModel : AopObject
    {
        /// <summary>
        /// 内容作者
        /// </summary>
        [XmlElement("author")]
        public string Author { get; set; }

        /// <summary>
        /// 内容分类code
        /// </summary>
        [XmlElement("category_code")]
        public string CategoryCode { get; set; }

        /// <summary>
        /// 内容分类名称
        /// </summary>
        [XmlElement("category_name")]
        public string CategoryName { get; set; }

        /// <summary>
        /// 内容详情，不包含页面样式
        /// </summary>
        [XmlElement("content")]
        public string Content { get; set; }

        /// <summary>
        /// 内容id
        /// </summary>
        [XmlElement("content_id")]
        public string ContentId { get; set; }

        /// <summary>
        /// 内容封面
        /// </summary>
        [XmlElement("cover")]
        public string Cover { get; set; }

        /// <summary>
        /// 内容详情H5链接
        /// </summary>
        [XmlElement("detail_url")]
        public string DetailUrl { get; set; }

        /// <summary>
        /// 图片链接列表，单个image大小不超过4096，image个数不超过50
        /// </summary>
        [XmlArray("image_list")]
        [XmlArrayItem("string")]
        public List<string> ImageList { get; set; }

        /// <summary>
        /// 内容修改时间，请确保本次修改的时间大于上一次修改的时间
        /// </summary>
        [XmlElement("modified_date")]
        public long ModifiedDate { get; set; }

        /// <summary>
        /// poi列表，单个poi名称大小不超过512，poi个数不超过50个
        /// </summary>
        [XmlArray("poi_list")]
        [XmlArrayItem("content_poi_data")]
        public List<ContentPoiData> PoiList { get; set; }

        /// <summary>
        /// 内容发布时间
        /// </summary>
        [XmlElement("publish_date")]
        public long PublishDate { get; set; }

        /// <summary>
        /// 标签列表，单个tag大小不超过128，tag个数不超过1000
        /// </summary>
        [XmlArray("tag_list")]
        [XmlArrayItem("string")]
        public List<string> TagList { get; set; }

        /// <summary>
        /// 内容标题
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }
    }
}
