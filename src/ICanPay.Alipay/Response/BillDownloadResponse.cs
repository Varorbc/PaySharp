namespace ICanPay.Alipay.Response
{
    public class BillDownloadResponse : BaseResponse
    {
        /// <summary>
        /// 账单下载地址链接，获取连接后30秒后未下载，链接地址失效。
        /// </summary>
        public string BillDownloadUrl { get; set; }
    }
}
