using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AntMerchantExpandAssetdeliveryCompleteSyncModel Data Structure.
    /// </summary>
    [Serializable]
    public class AntMerchantExpandAssetdeliveryCompleteSyncModel : AopObject
    {
        /// <summary>
        /// 配送完成反馈信息
        /// </summary>
        [XmlArray("asset_delivery_details")]
        [XmlArrayItem("asset_delivery_detail")]
        public List<AssetDeliveryDetail> AssetDeliveryDetails { get; set; }
    }
}
