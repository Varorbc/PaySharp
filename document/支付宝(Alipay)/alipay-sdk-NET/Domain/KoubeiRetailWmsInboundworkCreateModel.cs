using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiRetailWmsInboundworkCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiRetailWmsInboundworkCreateModel : AopObject
    {
        /// <summary>
        /// 扩展字段，json格式
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 该作业关联的入库/出库通知单id
        /// </summary>
        [XmlElement("notice_order_id")]
        public string NoticeOrderId { get; set; }

        /// <summary>
        /// 操作上下文
        /// </summary>
        [XmlElement("operate_context")]
        public OperateContext OperateContext { get; set; }

        /// <summary>
        /// 与作业相关的外部单据号，如菜鸟发货id
        /// </summary>
        [XmlElement("out_biz_no")]
        public string OutBizNo { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 入库作业明细列表
        /// </summary>
        [XmlArray("work_details")]
        [XmlArrayItem("work_detail")]
        public List<WorkDetail> WorkDetails { get; set; }
    }
}
