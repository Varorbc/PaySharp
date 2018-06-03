using PaySharp.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Unionpay.Domain
{
    public class CancelModel : BaseModel, IValidatableObject
    {
        public CancelModel()
        {
            BizType = "000000";
            TxnType = "31";
            TxnSubType = "00";
            ChannelType = "07";
        }

        /// <summary>
        /// 交易金额,单位分,与原消费交易一致
        /// </summary>
        [Required(ErrorMessage = "请设置交易金额")]
        [ReName(Name = "txnAmt")]
        public int CancelAmount { get; set; }

        /// <summary>
        /// 商户撤销订单号
        /// </summary>
        [Required(ErrorMessage = "请设置商户撤销订单号")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "商户撤销订单号最小长度为8位,最大长度为40位")]
        public string OrderId { get; set; }

        /// <summary>
        /// 渠道类型
        /// </summary>
        [Required(ErrorMessage = "请设置渠道类型")]
        public string ChannelType { get; private set; }

        /// <summary>
        /// 原交易查询流水号
        /// </summary>
        public string OrigQryId { get; set; }

        /// <summary>
        /// 原交易商户订单号
        /// </summary>
        public string OrigOrderId { get; set; }

        /// <summary>
        /// 原交易商户发送交易时间
        /// </summary>
        public string OrigTxnTime { get; } = DateTime.Now.ToString("yyyyMMddHHmmss");

        /// <summary>
        /// 保留域
        /// </summary>
        [StringLength(2048, ErrorMessage = "保留域最大长度为2048位")]
        public string Reserved { get; set; }

        /// <summary>
        /// 商户自定义保留域，交易应答时会原样返回
        /// </summary>
        [StringLength(1024, ErrorMessage = "商户自定义保留域最大长度为1024位")]
        public string ReqReserved { get; set; }

        /// <summary>
        /// 终端号
        /// </summary>
        public string TermId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(OrigOrderId) && string.IsNullOrEmpty(OrigQryId))
            {
                yield return new ValidationResult("原交易查询流水号和原交易商户订单号不能同时为空");
            }

            yield return ValidationResult.Success;
        }
    }
}
