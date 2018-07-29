using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// PassInstanceDetail Data Structure.
    /// </summary>
    [Serializable]
    public class PassInstanceDetail : AopObject
    {
        /// <summary>
        /// 业务动态参数列表
        /// </summary>
        [XmlArray("biz_param_list")]
        [XmlArrayItem("biz_param_key_value")]
        public List<BizParamKeyValue> BizParamList { get; set; }

        /// <summary>
        /// 所属商户PID/APPID（发放渠道ID）
        /// </summary>
        [XmlElement("channel_id")]
        public string ChannelId { get; set; }

        /// <summary>
        /// 卡券实例创建时间，格式"yyyy-MM-dd HH:mm:ss"
        /// </summary>
        [XmlElement("create_time")]
        public string CreateTime { get; set; }

        /// <summary>
        /// 有效期-结束时间，格式"yyyy-MM-dd HH:mm:ss"
        /// </summary>
        [XmlElement("end_date")]
        public string EndDate { get; set; }

        /// <summary>
        /// 删除标记，是否已被用户删除
        /// </summary>
        [XmlElement("is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// logo图片的ID或链接，模板创建时在模板JSON文本中指定
        /// </summary>
        [XmlElement("logo")]
        public string Logo { get; set; }

        /// <summary>
        /// 卡券展示标题
        /// </summary>
        [XmlElement("logo_text")]
        public string LogoText { get; set; }

        /// <summary>
        /// 最后修改时间，格式"yyyy-MM-dd HH:mm:ss"
        /// </summary>
        [XmlElement("modify_time")]
        public string ModifyTime { get; set; }

        /// <summary>
        /// 卡券实例id，对应调卡券发放alipay.pass.instance.add接口返回的passId
        /// </summary>
        [XmlElement("pass_id")]
        public string PassId { get; set; }

        /// <summary>
        /// 产品业务类型，模板创建时在模板JSON文本中指定
        /// </summary>
        [XmlElement("product")]
        public string Product { get; set; }

        /// <summary>
        /// 卡券单据号  由商户发券时指定的卡券唯一凭证号，卡券JSON模板中fileInfo->serialNumber字段对应的值
        /// </summary>
        [XmlElement("serial_number")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// 有效期-开始时间，格式"yyyy-MM-dd HH:mm:ss"
        /// </summary>
        [XmlElement("start_date")]
        public string StartDate { get; set; }

        /// <summary>
        /// 卡券状态：  CAN_USE：可使用；  EXPIRED：已过期；  USED：已使用（已核销）；  CLOSED：已失效；
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 图片/海报的图片ID或链接，模板创建时在模板JSON文本中指定
        /// </summary>
        [XmlElement("strip")]
        public string Strip { get; set; }

        /// <summary>
        /// 模板ID（编号）
        /// </summary>
        [XmlElement("tpl_id")]
        public string TplId { get; set; }

        /// <summary>
        /// 模板类型，模板创建时在模板JSON文本中指定
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }

        /// <summary>
        /// 所属用户user_id
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
