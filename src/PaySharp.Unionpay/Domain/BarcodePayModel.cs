namespace PaySharp.Unionpay.Domain
{
    public class BarcodePayModel : ScanPayModel
    {
        public BarcodePayModel()
        {
            BizType = "000000";
            TxnType = "01";
            TxnSubType = "06";
        }

        /// <summary>
        /// 二维码编号
        /// </summary>
        public string QrNo { get; set; }
    }
}
