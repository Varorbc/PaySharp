using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// DxVerifyResultItem Data Structure.
    /// </summary>
    [Serializable]
    public class DxVerifyResultItem : AopObject
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [XmlElement("error_code")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [XmlElement("error_msg")]
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 验证的输入参数，map的json格式序列化传递
        /// </summary>
        [XmlElement("input")]
        public string Input { get; set; }

        /// <summary>
        /// 行号
        /// </summary>
        [XmlElement("line")]
        public long Line { get; set; }

        /// <summary>
        /// 输出值，map的json格式序列化传递
        /// </summary>
        [XmlElement("output")]
        public string Output { get; set; }

        /// <summary>
        /// 预测的结果值，map的json 格式序列化传递
        /// </summary>
        [XmlElement("predict")]
        public string Predict { get; set; }

        /// <summary>
        /// 验证是否成功
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

        /// <summary>
        /// 验证路径
        /// </summary>
        [XmlElement("trace")]
        public string Trace { get; set; }
    }
}
