using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiRetailWmsInboundorderConfirmModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiRetailWmsInboundorderConfirmModel : AopObject
    {
        /// <summary>
        /// 入库通知单号
        /// </summary>
        [XmlElement("inbound_order_id")]
        public string InboundOrderId { get; set; }

        /// <summary>
        /// 操作人信息
        /// </summary>
        [XmlElement("operate_context")]
        public OperateContext OperateContext { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 入库单最终状态  FINISHED（完成），CANCELLED（取消）
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }
    }
}
