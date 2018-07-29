using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiRetailWmsDeliverypackageQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiRetailWmsDeliverypackageQueryModel : AopObject
    {
        /// <summary>
        /// 运单号（与通知单号二选一，如果都存在，以通知单号查询）
        /// </summary>
        [XmlElement("express_code")]
        public string ExpressCode { get; set; }

        /// <summary>
        /// 通知单id（与运单号二选一）
        /// </summary>
        [XmlElement("notice_order_id")]
        public string NoticeOrderId { get; set; }

        /// <summary>
        /// 操作上下文
        /// </summary>
        [XmlElement("operate_context")]
        public OperateContext OperateContext { get; set; }

        /// <summary>
        /// 作业id
        /// </summary>
        [XmlElement("work_order_id")]
        public string WorkOrderId { get; set; }
    }
}
