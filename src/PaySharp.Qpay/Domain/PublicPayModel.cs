namespace PaySharp.Qpay.Domain
{
    public class PublicPayModel : BasePayModel
    {
        public PublicPayModel()
        {
            TradeType = "JSAPI";
        }
    }
}
