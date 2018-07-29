using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiRetailWmsOutboundorderConfirmModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiRetailWmsOutboundorderConfirmModel : AopObject
    {
        /// <summary>
        /// 操作人信息
        /// </summary>
        [XmlElement("operate_context")]
        public OperateContext OperateContext { get; set; }

        /// <summary>
        /// 出库通知单id
        /// </summary>
        [XmlElement("outbound_order_id")]
        public string OutboundOrderId { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 出库单最终状态：FINISHED（完成），CANCELLED（取消）
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }
    }
}
