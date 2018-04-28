using System.ComponentModel.DataAnnotations;

namespace PaySharp.Alipay.Domain
{
    public class CloseModel : QueryModel
    {
        /// <summary>
        /// 卖家端自定义的的操作员编号
        /// </summary>
        [StringLength(28, ErrorMessage = "卖家端自定义的的操作员编号最大长度为28位")]
        public string OperatorId { get; set; }
    }
}
