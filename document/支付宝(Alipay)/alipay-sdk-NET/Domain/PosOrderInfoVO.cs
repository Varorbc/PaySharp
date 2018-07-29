using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// PosOrderInfoVO Data Structure.
    /// </summary>
    [Serializable]
    public class PosOrderInfoVO : AopObject
    {
        /// <summary>
        /// 设备数量
        /// </summary>
        [XmlElement("device_amount")]
        public long DeviceAmount { get; set; }

        /// <summary>
        /// 数据回流ISV名称
        /// </summary>
        [XmlElement("isv_name")]
        public string IsvName { get; set; }

        /// <summary>
        /// 数据回流ISV_PID
        /// </summary>
        [XmlElement("isv_pid")]
        public string IsvPid { get; set; }

        /// <summary>
        /// 订单绑定设备信息列表
        /// </summary>
        [XmlArray("machine_infos")]
        [XmlArrayItem("pos_order_device_info_v_o")]
        public List<PosOrderDeviceInfoVO> MachineInfos { get; set; }

        /// <summary>
        /// 商户手机号
        /// </summary>
        [XmlElement("merchant_mobile")]
        public string MerchantMobile { get; set; }

        /// <summary>
        /// 商户名称
        /// </summary>
        [XmlElement("merchant_name")]
        public string MerchantName { get; set; }

        /// <summary>
        /// 购买pos机订单总价格，单位元，精确到小数点后2位
        /// </summary>
        [XmlElement("order_amt")]
        public string OrderAmt { get; set; }

        /// <summary>
        /// 购买pos机设备订单来源，分为线下和线上,枚举值为: 线上(ONLINE),线下(OFFLINE)
        /// </summary>
        [XmlElement("order_channel")]
        public string OrderChannel { get; set; }

        /// <summary>
        /// 购买pos机设备订单编号：线上来源订单为订单编号，线下来源订单为合同编号
        /// </summary>
        [XmlElement("order_no")]
        public string OrderNo { get; set; }

        /// <summary>
        /// 销售人员id
        /// </summary>
        [XmlElement("seller_id")]
        public string SellerId { get; set; }

        /// <summary>
        /// 销售人员名称
        /// </summary>
        [XmlElement("seller_name")]
        public string SellerName { get; set; }

        /// <summary>
        /// 淘宝账号
        /// </summary>
        [XmlElement("taobao_login_id")]
        public string TaobaoLoginId { get; set; }
    }
}
