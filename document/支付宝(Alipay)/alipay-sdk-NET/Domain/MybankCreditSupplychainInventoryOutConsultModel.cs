using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// MybankCreditSupplychainInventoryOutConsultModel Data Structure.
    /// </summary>
    [Serializable]
    public class MybankCreditSupplychainInventoryOutConsultModel : AopObject
    {
        /// <summary>
        /// 贷款合约编号
        /// </summary>
        [XmlElement("ar_no")]
        public string ArNo { get; set; }

        /// <summary>
        /// 资产列表
        /// </summary>
        [XmlArray("asset_info_list")]
        [XmlArrayItem("inventory_info")]
        public List<InventoryInfo> AssetInfoList { get; set; }

        /// <summary>
        /// 客户身份信息，在预付融资中代表的是买家的身份
        /// </summary>
        [XmlElement("customer")]
        public Member Customer { get; set; }

        /// <summary>
        /// 外部订单号，格式：机构ipRoleId_外部订单号
        /// </summary>
        [XmlElement("out_order_no")]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 销售产品码
        /// </summary>
        [XmlElement("sale_pd_code")]
        public string SalePdCode { get; set; }

        /// <summary>
        /// FACTORING：保理，PREPAYMENT：预付融资，CREDITPAY：信任付
        /// </summary>
        [XmlElement("trade_type")]
        public string TradeType { get; set; }
    }
}
