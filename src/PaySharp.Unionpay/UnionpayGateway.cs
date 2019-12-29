#if NETCOREAPP3_1
using Microsoft.Extensions.Options;
#endif
using System;
using System.Threading.Tasks;
using PaySharp.Core;
using PaySharp.Core.Request;
using PaySharp.Core.Utils;
using PaySharp.Unionpay.Request;
using PaySharp.Unionpay.Response;

namespace PaySharp.Unionpay
{
    /// <summary>
    /// 中国银联网关
    /// </summary>
    public sealed class UnionpayGateway : BaseGateway
    {
        #region 私有字段

        private readonly Merchant _merchant;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化中国银联网关
        /// </summary>
        /// <param name="merchant">商户数据</param>
        public UnionpayGateway(Merchant merchant)
            : base(merchant)
        {
            _merchant = merchant;

            _merchant.CertId = Util.GetCertId(merchant.CertPath, merchant.CertPwd);
            _merchant.CertKey = Util.GetCertKey(merchant.CertPath, merchant.CertPwd);
        }

#if NETCOREAPP3_1

        /// <summary>
        /// 初始化中国银联网关
        /// </summary>
        /// <param name="merchant">商户数据</param>
        public UnionpayGateway(IOptions<Merchant> merchant)
           : this(merchant.Value)
        {
        }

#endif

        #endregion

        #region 属性

        public override string GatewayUrl { get; set; } = "https://gateway.95516.com";

        public new Merchant Merchant => _merchant;

        public new NotifyResponse NotifyResponse => (NotifyResponse)base.NotifyResponse;

        protected override bool IsPaySuccess => NotifyResponse.TxnType == "01" && NotifyResponse.RespCode == "00";

        protected override bool IsRefundSuccess => NotifyResponse.TxnType == "04" && NotifyResponse.RespCode == "00";

        protected override bool IsCancelSuccess => NotifyResponse.TxnType == "31" && NotifyResponse.RespCode == "00";

        protected override string[] NotifyVerifyParameter => new string[]
        {
            "merId",  "respCode", "respMsg", "queryId", "signMethod"
        };

        #endregion

        protected override async Task<bool> ValidateNotifyAsync()
        {
            base.NotifyResponse = await GatewayData.ToObjectAsync<NotifyResponse>(StringCase.Camel);
            base.NotifyResponse.Raw = GatewayData.ToUrl(false);

            var gatewayData = new GatewayData(StringComparer.Ordinal);
            gatewayData.FromUrl(NotifyResponse.Raw, false);
            return SubmitProcess.CheckSign(gatewayData, NotifyResponse.Sign, NotifyResponse.SignPubKeyCert);
        }

        public override TResponse Execute<TModel, TResponse>(Request<TModel, TResponse> request)
        {
            if (request is WebPayRequest || request is WapPayRequest)
            {
                return SubmitProcess.SdkExecute(_merchant, request, GatewayUrl);
            }

            return SubmitProcess.Execute(_merchant, request, GatewayUrl);
        }

        protected override void WriteFailureFlag()
        {
            HttpUtil.Current.Response.StatusCode = 404;
        }
    }
}
