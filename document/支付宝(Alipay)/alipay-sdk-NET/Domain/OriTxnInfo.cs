using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// OriTxnInfo Data Structure.
    /// </summary>
    [Serializable]
    public class OriTxnInfo : AopObject
    {
        /// <summary>
        /// 原始交易描述分类。    biz_scene=LOCAL时忽略该参数。
        /// </summary>
        [XmlElement("category_type")]
        public string CategoryType { get; set; }

        /// <summary>
        /// 原始交易描述分类值。    biz_scene=LOCAL时忽略该参数。
        /// </summary>
        [XmlElement("category_value")]
        public string CategoryValue { get; set; }

        /// <summary>
        /// 原始交易信息明细。格式：交易日期YYYYMMDD|商户交易订单号|交易币种|交易金额。    biz_scene=LOCAL时忽略该参数。  暂时无用参数, 请忽略.使用需要与支付宝沟通.
        /// </summary>
        [XmlElement("txn_info")]
        public string TxnInfo { get; set; }
    }
}
