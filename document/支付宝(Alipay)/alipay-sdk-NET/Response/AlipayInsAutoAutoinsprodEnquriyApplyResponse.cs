using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Aop.Api.Domain;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayInsAutoAutoinsprodEnquriyApplyResponse.
    /// </summary>
    public class AlipayInsAutoAutoinsprodEnquriyApplyResponse : AopResponse
    {
        /// <summary>
        /// 车辆的品牌型号列表
        /// </summary>
        [XmlArray("car_model")]
        [XmlArrayItem("car_model")]
        public List<CarModel> CarModel { get; set; }

        /// <summary>
        /// 车险询价申请号
        /// </summary>
        [XmlElement("enquiry_biz_id")]
        public string EnquiryBizId { get; set; }

        /// <summary>
        /// 外部询价申请业务单号（幂等字段）
        /// </summary>
        [XmlElement("out_biz_no")]
        public string OutBizNo { get; set; }
    }
}
