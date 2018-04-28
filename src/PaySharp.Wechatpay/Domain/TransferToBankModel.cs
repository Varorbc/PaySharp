using PaySharp.Core;
using PaySharp.Core.Utils;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Wechatpay.Domain
{
    public class TransferToBankModel
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        [ReName(Name = "partner_trade_no")]
        [Required(ErrorMessage = "请设置商户订单号")]
        [StringLength(32, ErrorMessage = "商户订单号最大长度为32位")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; } = Util.GenerateNonceStr();

        /// <summary>
        /// 收款方银行卡号	
        /// </summary>
        [ReName(Name = "enc_bank_no")]
        [Required(ErrorMessage = "请设置收款方银行卡号")]
        [StringLength(64, ErrorMessage = "收款方银行卡号最大长度为64位")]
        public string BankNo { get; set; }

        /// <summary>
        /// 收款方用户名	
        /// </summary>
        [ReName(Name = "enc_true_name")]
        [Required(ErrorMessage = "请设置收款方用户名")]
        [StringLength(64, ErrorMessage = "收款方用户名最大长度为64位")]
        public string TrueName { get; set; }

        /// <summary>
        /// 收款方开户行
        /// 银行卡所在开户行编号,详见银行编号列表https://pay.weixin.qq.com/wiki/doc/api/tools/mch_pay.php?chapter=24_4
        /// </summary>
        [Required(ErrorMessage = "请设置收款方开户行")]
        [StringLength(64, ErrorMessage = "收款方开户行最大长度为64位")]
        public string BankCode { get; set; }

        /// <summary>
        /// 付款金额：RMB分（支付总额，不含手续费） 
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 付款说明
        /// </summary>
        public string Desc { get; set; }
    }
}
