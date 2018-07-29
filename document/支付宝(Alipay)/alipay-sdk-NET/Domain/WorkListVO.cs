using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// WorkListVO Data Structure.
    /// </summary>
    [Serializable]
    public class WorkListVO : AopObject
    {
        /// <summary>
        /// 作业完成时间
        /// </summary>
        [XmlElement("gmt_finished")]
        public string GmtFinished { get; set; }

        /// <summary>
        /// 作业对应的入库/出库通知单的外部业务单据号，这个单据可能是采购单、补货单等
        /// </summary>
        [XmlElement("notice_out_biz_no")]
        public string NoticeOutBizNo { get; set; }

        /// <summary>
        /// 作业对应的通知单的外部业务类型，BHRK=补货入库，CGRK=采购入库，CGTHRK=采购退货入库，DDTHRK=订单退货入库，PDRK=盘点入库，CGCK=采购出库，DDCK=订单出库，PDCK=盘点出库，BHCK=补货出库
        /// </summary>
        [XmlElement("notice_out_biz_type")]
        public string NoticeOutBizType { get; set; }

        /// <summary>
        /// 操作员id
        /// </summary>
        [XmlElement("operator")]
        public string Operator { get; set; }

        /// <summary>
        /// 作业状态，INIT=待提交，SUCCEED=已完成
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 仓库编号
        /// </summary>
        [XmlElement("warehouse_code")]
        public string WarehouseCode { get; set; }

        /// <summary>
        /// 作业id
        /// </summary>
        [XmlElement("work_id")]
        public string WorkId { get; set; }

        /// <summary>
        /// 作业类型，INBOUND-入库，OUTBOUND-出库
        /// </summary>
        [XmlElement("work_type")]
        public string WorkType { get; set; }
    }
}
