using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// SceneContent Data Structure.
    /// </summary>
    [Serializable]
    public class SceneContent : AopObject
    {
        /// <summary>
        /// 文章分类
        /// </summary>
        [XmlElement("article_classify")]
        public long ArticleClassify { get; set; }

        /// <summary>
        /// 文章作者
        /// </summary>
        [XmlElement("author")]
        public string Author { get; set; }

        /// <summary>
        /// 文章id
        /// </summary>
        [XmlElement("content_id")]
        public string ContentId { get; set; }

        /// <summary>
        /// 文章封面图片
        /// </summary>
        [XmlElement("cover")]
        public string Cover { get; set; }

        /// <summary>
        /// 文章图片列表
        /// </summary>
        [XmlArray("image_list")]
        [XmlArrayItem("string")]
        public List<string> ImageList { get; set; }

        /// <summary>
        /// 生活号id
        /// </summary>
        [XmlElement("public_id")]
        public string PublicId { get; set; }

        /// <summary>
        /// public_name为生活号名称，属于公开信息，无需脱敏
        /// </summary>
        [XmlElement("public_name")]
        public string PublicName { get; set; }

        /// <summary>
        /// 跳转链接
        /// </summary>
        [XmlElement("scheme")]
        public string Scheme { get; set; }

        /// <summary>
        /// 推荐埋点
        /// </summary>
        [XmlElement("scm")]
        public string Scm { get; set; }

        /// <summary>
        /// 文章摘要
        /// </summary>
        [XmlElement("summary")]
        public string Summary { get; set; }

        /// <summary>
        /// 文章标题
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// 文章点赞数
        /// </summary>
        [XmlElement("total_praise_count")]
        public long TotalPraiseCount { get; set; }

        /// <summary>
        /// 文章回复数
        /// </summary>
        [XmlElement("total_reply_count")]
        public long TotalReplyCount { get; set; }

        /// <summary>
        /// 文章阅读数
        /// </summary>
        [XmlElement("total_view_count")]
        public long TotalViewCount { get; set; }

        /// <summary>
        /// 文章类型
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }
    }
}
