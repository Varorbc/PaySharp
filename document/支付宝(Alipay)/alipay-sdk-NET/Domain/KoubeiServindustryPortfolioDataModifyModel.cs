using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiServindustryPortfolioDataModifyModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiServindustryPortfolioDataModifyModel : AopObject
    {
        /// <summary>
        /// 头图素材ID
        /// </summary>
        [XmlElement("cover_media_id")]
        public string CoverMediaId { get; set; }

        /// <summary>
        /// 头图素材type,枚举(PICTURE/VIDEO),更改头图时必传
        /// </summary>
        [XmlElement("cover_media_type")]
        public string CoverMediaType { get; set; }

        /// <summary>
        /// 作品集id
        /// </summary>
        [XmlElement("portfolio_id")]
        public string PortfolioId { get; set; }

        /// <summary>
        /// 操作人信息
        /// </summary>
        [XmlElement("portfolio_operator_info")]
        public PortfolioOperatorInfo PortfolioOperatorInfo { get; set; }

        /// <summary>
        /// 作品集门店关系&展示权重,需要传要关联的全部店铺,更新模式为覆盖
        /// </summary>
        [XmlArray("portfolio_shops")]
        [XmlArrayItem("portfolio_shop")]
        public List<PortfolioShop> PortfolioShops { get; set; }

        /// <summary>
        /// 作品集标题
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }
    }
}
