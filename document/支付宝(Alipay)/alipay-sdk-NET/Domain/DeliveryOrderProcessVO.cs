using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// DeliveryOrderProcessVO Data Structure.
    /// </summary>
    [Serializable]
    public class DeliveryOrderProcessVO : AopObject
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        [XmlElement("gmt_create")]
        public string GmtCreate { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [XmlElement("gmt_modified")]
        public string GmtModified { get; set; }

        /// <summary>
        /// 操作内容
        /// </summary>
        [XmlElement("operate_info")]
        public string OperateInfo { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        [XmlElement("operate_time")]
        public string OperateTime { get; set; }

        /// <summary>
        /// 操作人编码
        /// </summary>
        [XmlElement("operator_code")]
        public string OperatorCode { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [XmlElement("operator_name")]
        public string OperatorName { get; set; }

        /// <summary>
        /// 通知单id
        /// </summary>
        [XmlElement("order_code")]
        public string OrderCode { get; set; }

        /// <summary>
        /// 菜鸟订单id
        /// </summary>
        [XmlElement("order_id")]
        public string OrderId { get; set; }

        /// <summary>
        /// 订单类型  CGRK=采购入库  JYCK＝交易出库
        /// </summary>
        [XmlElement("order_type")]
        public string OrderType { get; set; }

        /// <summary>
        /// 订单状态  发货物流状态：ACCEPT=仓库接单; PRINT = 打印;PICK=捡货;CHECK = 复核 ;PACKAGE= 打包;WEIGH= 称重;READY=待提货;DELIVERED=已发货;REFUSE=买家拒签;EXCEPTION =异常;CLOSED= 关闭;CANCELED= 取 消;REJECT=仓库拒单;SIGN=签收;TMSCANCELED=快递拦截;OTHER=其他;PARTDELIVERED=部分发货完成;TMSCANCELFAILED=快递拦截失败。  补货单物流状态：ACCEPT=仓库接单;PARTFULFILLED-部分收货完成;FULFILLED=收货完成; EXCEPTION =异常;CLOSED= 关闭;CANCELED= 取 消;REJECT=仓库拒单;
        /// </summary>
        [XmlElement("process_status")]
        public string ProcessStatus { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }
    }
}
