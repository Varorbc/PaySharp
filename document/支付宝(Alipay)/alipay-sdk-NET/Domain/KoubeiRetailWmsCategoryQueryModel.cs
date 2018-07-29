using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiRetailWmsCategoryQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiRetailWmsCategoryQueryModel : AopObject
    {
        /// <summary>
        /// 根据类目ID查询
        /// </summary>
        [XmlElement("category_id")]
        public string CategoryId { get; set; }

        /// <summary>
        /// 操作上下文
        /// </summary>
        [XmlElement("operate_context")]
        public OperateContext OperateContext { get; set; }
    }
}
