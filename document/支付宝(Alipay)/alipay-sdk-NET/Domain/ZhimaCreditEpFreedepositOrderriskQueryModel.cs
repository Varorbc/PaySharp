using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ZhimaCreditEpFreedepositOrderriskQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class ZhimaCreditEpFreedepositOrderriskQueryModel : AopObject
    {
        /// <summary>
        /// 本次使用免押金额，分
        /// </summary>
        [XmlElement("current_use_limit")]
        public long CurrentUseLimit { get; set; }

        /// <summary>
        /// 企业证件号
        /// </summary>
        [XmlElement("ep_cert_no")]
        public string EpCertNo { get; set; }

        /// <summary>
        /// 企业证件类型
        /// </summary>
        [XmlElement("ep_cert_type")]
        public string EpCertType { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        [XmlElement("ep_name")]
        public string EpName { get; set; }

        /// <summary>
        /// 首笔租金金额，分
        /// </summary>
        [XmlElement("first_rent_amount")]
        public long FirstRentAmount { get; set; }

        /// <summary>
        /// 租期期数
        /// </summary>
        [XmlElement("lease_periods")]
        public long LeasePeriods { get; set; }

        /// <summary>
        /// 租赁设备信息列表
        /// </summary>
        [XmlArray("machine_info_list")]
        [XmlArrayItem("machine_info")]
        public List<MachineInfo> MachineInfoList { get; set; }

        /// <summary>
        /// 订单风控业务流水号，商户生成，每次业务保证唯一
        /// </summary>
        [XmlElement("merchant_lease_order_no")]
        public string MerchantLeaseOrderNo { get; set; }

        /// <summary>
        /// 超出免押额度部分的应交押金(人民币分)
        /// </summary>
        [XmlElement("need_pay_deposit_amount")]
        public long NeedPayDepositAmount { get; set; }

        /// <summary>
        /// 芝麻企业免押额度申请业务流水号
        /// </summary>
        [XmlElement("order_no")]
        public string OrderNo { get; set; }

        /// <summary>
        /// 付款日
        /// </summary>
        [XmlElement("pay_date")]
        public string PayDate { get; set; }

        /// <summary>
        /// 每期租金金额，分
        /// </summary>
        [XmlElement("period_lease_amount")]
        public long PeriodLeaseAmount { get; set; }

        /// <summary>
        /// 产品ID
        /// </summary>
        [XmlElement("product_code")]
        public string ProductCode { get; set; }

        /// <summary>
        /// 收货地址
        /// </summary>
        [XmlElement("rec_address")]
        public string RecAddress { get; set; }

        /// <summary>
        /// 收货人手机号
        /// </summary>
        [XmlElement("rec_mobile")]
        public string RecMobile { get; set; }

        /// <summary>
        /// 收货人姓名
        /// </summary>
        [XmlElement("rec_name")]
        public string RecName { get; set; }

        /// <summary>
        /// 剩余可用免押金额，分
        /// </summary>
        [XmlElement("remain_limit")]
        public long RemainLimit { get; set; }

        /// <summary>
        /// 租赁总金额，分
        /// </summary>
        [XmlElement("total_amount")]
        public long TotalAmount { get; set; }
    }
}
