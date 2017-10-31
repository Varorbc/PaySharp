using ICanPay.Core;
using System.ComponentModel.DataAnnotations;

namespace ICanPay.Wechatpay
{
    public class Auxiliary : IAuxiliary
    {
        /// <summary>
        /// 商户系统内部订单号，要求32个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一。
        /// </summary>
        [StringLength(32, ErrorMessage = "商户系统内部订单号为32位")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 微信的订单号，建议优先使用
        /// </summary>
        [ReName(Name = Constant.TRANSACTION_ID)]
        public string TradeNo { get; set; }

        public bool Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
