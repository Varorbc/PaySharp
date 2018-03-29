namespace ICanPay.Alipay.Response
{
    public class CancelResponse : BaseResponse
    {
        /// <summary>
        /// 是否需要重试
        /// </summary>
        public string RetryFlag { get; set; }

        /// <summary>
        /// 本次撤销触发的交易动作 
        /// close：关闭交易，无退款
        /// refund：产生了退款
        /// </summary>
        public string Action { get; set; }
    }
}
