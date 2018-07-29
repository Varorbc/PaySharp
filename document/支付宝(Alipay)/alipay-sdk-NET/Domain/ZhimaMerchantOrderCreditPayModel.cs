using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ZhimaMerchantOrderCreditPayModel Data Structure.
    /// </summary>
    [Serializable]
    public class ZhimaMerchantOrderCreditPayModel : AopObject
    {
        /// <summary>
        /// CANCEL，FINISH, INSTALLMENT  订单完结类型，目前包括取消(CANCEL)、完结(FINISH) 分期扣款(INSTALLMENT)
        /// </summary>
        [XmlElement("order_operate_type")]
        public string OrderOperateType { get; set; }

        /// <summary>
        /// 外部订单号,包含字母、数字、下划线，调用方需要保证订单号唯一
        /// </summary>
        [XmlElement("out_order_no")]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 外部资金订单号，可包含字母、数字、下划线
        /// </summary>
        [XmlElement("out_trans_no")]
        public string OutTransNo { get; set; }

        /// <summary>
        /// 支付总金额，单位为元，精确到小数点后两位，取值范围[0.01,100000000]，无支付行为时为空，例如订单取消或者支付金额为0
        /// </summary>
        [XmlElement("pay_amount")]
        public string PayAmount { get; set; }

        /// <summary>
        /// 订单操作说明
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 芝麻订单号
        /// </summary>
        [XmlElement("zm_order_no")]
        public string ZmOrderNo { get; set; }
    }
}
