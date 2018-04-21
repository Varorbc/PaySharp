namespace PaySharp.Unionpay.Domain
{
    public class WebPayModel : BasePayModel
    {
        /// <summary>
        /// 有卡交易信息域
        /// </summary>
        public string CardTransData { get; set; }

        /// <summary>
        /// 预付卡通道
        /// </summary>
        public string AccountPayChannel { get; set; }

        /// <summary>
        /// 账号类型(卡介质)
        /// 01：银行卡
        /// 02：存折
        /// 03：IC卡
        /// 默认取值：01
        /// </summary>
        public string AccType { get; set; } = "01";

        /// <summary>
        /// 订单接收超时时间,单位为毫秒，
        /// 交易发生时，该笔交易在银联全渠道系统中有效的最长时间。
        /// 当距离交易发送时间超过该时间时，银联全渠道系统不再为该笔交易提供支付服务
        /// </summary>
        public string OrderTimeout { get; set; }

        /// <summary>
        /// 支持支付方式,仅仅pc使用，使用哪种支付方式 
        /// 由收单机构填写，取值为以下内容的一种或多种，通过逗号（，）分割。取值参考数据字典
        /// </summary>
        public string SupPayType { get; set; }

        /// <summary>
        /// 持卡人IP
        /// </summary>
        public string CustomerIp { get; set; }


        /// <summary>
        /// 终端号
        /// </summary>
        public string TermId { get; set; }
    }
}
