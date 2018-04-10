using ICanPay.Alipay.Request;
using ICanPay.Core;
using ICanPay.Core.Exceptions;
using ICanPay.Core.Request;
using ICanPay.Core.Utils;
using System.Threading.Tasks;

namespace ICanPay.Alipay
{
    /// <summary>
    /// 支付宝网关
    /// </summary>
    public sealed class AlipayGateway : BaseGateway
    {
        #region 私有字段

        private readonly Merchant _merchant;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化支付宝网关
        /// </summary>
        /// <param name="merchant">商户数据</param>
        public AlipayGateway(Merchant merchant)
            : base(merchant)
        {
            _merchant = merchant;
        }

        #endregion

        #region 属性

        public override string GatewayUrl { get; set; } = "https://openapi.alipay.com";

        public new Notify Notify => (Notify)base.Notify;

        protected override bool IsSuccessPay => Notify.TradeStatus == "TRADE_SUCCESS";

        protected override string[] NotifyVerifyParameter => new string[]
        {
            "app_id","version", "charset","trade_no", "sign","sign_type"
        };

        #endregion

        #region 公共方法

        protected override async Task<bool> ValidateNotifyAsync()
        {
            base.Notify = await GatewayData.ToObjectAsync<Notify>(StringCase.Snake);
            GatewayData.Remove("sign");
            GatewayData.Remove("sign_type");

            bool result = EncryptUtil.RSAVerifyData(GatewayData.ToUrl(false),
                Notify.Sign, _merchant.AlipayPublicKey, _merchant.SignType);
            if (result)
            {
                return true;
            }

            throw new GatewayException("签名不一致");
        }

        public override TResponse Execute<TModel, TResponse>(Request<TModel, TResponse> request)
        {
            request.RequestUrl = GatewayUrl + request.RequestUrl;

            if (request is WapPayRequest || request is WebPayRequest || request is AppPayRequest)
            {
                return SubmitProcess.SdkExecute(_merchant, request);
            }

            return SubmitProcess.Execute(_merchant, request);
        }

        #endregion
    }
}