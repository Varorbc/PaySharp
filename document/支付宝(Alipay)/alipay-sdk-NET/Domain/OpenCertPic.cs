using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// OpenCertPic Data Structure.
    /// </summary>
    [Serializable]
    public class OpenCertPic : AopObject
    {
        /// <summary>
        /// 图片的base64字符串，不需要base64头(data:image/jpeg;base64,)
        /// </summary>
        [XmlElement("data")]
        public string Data { get; set; }

        /// <summary>
        /// DRIVING_LICENSE_HOME_PAGE:主页;  DRIVING_LICENSE_SUB_PAGE:副页;
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }
    }
}
