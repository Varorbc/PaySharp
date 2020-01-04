#if NETCOREAPP3_1
using Microsoft.Extensions.Options;
#endif
using System.Threading.Tasks;
using PaySharp.Allinpay.Response;
using PaySharp.Core;
using PaySharp.Core.Exceptions;
using PaySharp.Core.Request;
using PaySharp.Core.Utils;

namespace PaySharp.Allinpay
{
    /// <summary>
    /// 通联收银宝网关
    /// </summary>
    public sealed class AllinpayGateway : BaseGateway
    {
        #region 私有字段

        private readonly Merchant _merchant;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化通联收银宝网关
        /// </summary>
        /// <param name="merchant">商户数据</param>
        public AllinpayGateway(Merchant merchant)
            : base(merchant)
        {
            _merchant = merchant;
        }

#if NETCOREAPP3_1

        /// <summary>
        /// 初始化通联收银宝网关
        /// </summary>
        /// <param name="merchant">商户数据</param>
        public AllinpayGateway(IOptions<Merchant> merchant)
            : this(merchant.Value)
        {
        }

#endif

        #endregion

        #region 属性

        public override string GatewayUrl { get; set; } = "https://vsp.allinpay.com";

        public new NotifyResponse NotifyResponse => (NotifyResponse)base.NotifyResponse;

        protected override bool IsPaySuccess => NotifyResponse.TradeStatus == "0000";

        protected override bool IsRefundSuccess { get; }

        protected override bool IsCancelSuccess { get; }

        protected override string[] NotifyVerifyParameter => new string[]
        {
            "appid", "trxcode", "trxid", "cusid"
        };

        #endregion

        #region 方法

        protected override async Task<bool> ValidateNotifyAsync()
        {
            base.NotifyResponse = await GatewayData.ToObjectAsync<NotifyResponse>(StringCase.Lower);
            base.NotifyResponse.Raw = GatewayData.Raw;

            if (!SubmitProcess.CheckSign(GatewayData, _merchant.Key, NotifyResponse.Sign))
            {
                throw new GatewayException("签名不一致");
            }

            return true;
        }

        public override TResponse Execute<TModel, TResponse>(Request<TModel, TResponse> request)
        {
            return SubmitProcess.Execute(_merchant, request, GatewayUrl);
        }

        #endregion
    }
}
