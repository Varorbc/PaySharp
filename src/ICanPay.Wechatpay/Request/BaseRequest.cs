using ICanPay.Core.Request;
using ICanPay.Core.Response;
using ICanPay.Core.Utils;

namespace ICanPay.Wechatpay.Request
{
    public class BaseRequest<TModel, TResponse> : Request<TModel, TResponse> where TResponse : IResponse
    {
        public BaseRequest()
        {
            RequestUrl = "/pay/unifiedorder";
        }

        public override void AddGatewayData(TModel model)
        {
            base.AddGatewayData(model);

            GatewayData.Add(model, StringCase.Snake);
        }

        /// <summary>
        /// 是否需要使用证书
        /// </summary>
        internal bool IsUseCert { get; set; }

        internal virtual void Execute(Merchant merchant)
        {
            if (!string.IsNullOrEmpty(NotifyUrl))
            {
                GatewayData.Add("notify_url", NotifyUrl);
            }
        }
    }
}
