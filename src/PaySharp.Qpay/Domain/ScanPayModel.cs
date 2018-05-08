namespace PaySharp.Qpay.Domain
{
    public class ScanPayModel : BasePayModel
    {
        public ScanPayModel()
        {
            TradeType = "NATIVE";
        }
    }
}
