using ICanPay.Core;
using ICanPay.Core.Exceptions;
using ICanPay.Core.Request;
using ICanPay.Core.Response;
using ICanPay.Core.Utils;
using ICanPay.Wechatpay.Response;
using System.Threading.Tasks;

namespace ICanPay.Wechatpay
{
    internal static class SubmitProcess
    {
        internal static TResponse Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request) where TResponse : IResponse
        {
            AddMerchant(merchant, request);

            string result = null;
            Task.Run(async () =>
            {
                result = await HttpUtil
                 .PostAsync(request.RequestUrl, request.GatewayData.ToXml());
            })
            .GetAwaiter()
            .GetResult();

            var gatewayData = new GatewayData();
            gatewayData.FromXml(result);

            var baseResponse = (BaseResponse)(object)gatewayData.ToObject<TResponse>(StringCase.Snake);
            baseResponse.Raw = result;
            if (baseResponse.ReturnCode == "SUCCESS")
            {
                string sign = gatewayData.GetStringValue(Constant.SIGN);

                if (!CheckSign(gatewayData, merchant.Key, sign))
                {
                    throw new GatewayException("签名验证失败");
                }

                baseResponse.Execute(merchant, request);
            }

            return (TResponse)(object)baseResponse;
        }

        private static void AddMerchant<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request) where TResponse : IResponse
        {
            request.GatewayData.Add(merchant, StringCase.Snake);
            if (!string.IsNullOrEmpty(request.NotifyUrl))
            {
                request.GatewayData.Add("notify_url", request.NotifyUrl);
            }
            request.GatewayData.Add(Constant.SIGN, BuildSign(request.GatewayData, merchant.Key));
        }

        internal static string BuildSign(GatewayData gatewayData, string key)
        {
            gatewayData.Remove(Constant.SIGN);

            string data = $"{gatewayData.ToUrl(false)}&key={key}";
            return EncryptUtil.MD5(data);
        }

        internal static bool CheckSign(GatewayData gatewayData, string key, string sign)
        {
            return BuildSign(gatewayData, key) == sign;
        }
    }
}
