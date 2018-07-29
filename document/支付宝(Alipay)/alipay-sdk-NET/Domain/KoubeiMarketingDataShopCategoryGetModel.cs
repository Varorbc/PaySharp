using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiMarketingDataShopCategoryGetModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiMarketingDataShopCategoryGetModel : AopObject
    {
        /// <summary>
        /// 该参数标识需要返回几个分类，多余的分类将会放于other字段中，最大值传入50，默认值10
        /// </summary>
        [XmlElement("count")]
        public long Count { get; set; }

        /// <summary>
        /// 商圈ID
        /// </summary>
        [XmlElement("mall_id")]
        public string MallId { get; set; }
    }
}
