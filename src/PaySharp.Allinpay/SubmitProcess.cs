using System.Threading.Tasks;
using PaySharp.Allinpay.Request;
using PaySharp.Allinpay.Response;
using PaySharp.Core;
using PaySharp.Core.Exceptions;
using PaySharp.Core.Request;
using PaySharp.Core.Response;
using PaySharp.Core.Utils;

namespace PaySharp.Allinpay
{
    internal static class SubmitProcess
    {
        private static string _gatewayUrl;

        internal static TResponse Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request, string gatewayUrl = null) where TResponse : IResponse
        {
            AddMerchant(merchant, request, gatewayUrl);

            var sign = BuildSign(request.GatewayData, merchant.Key);
            request.GatewayData.Add("sign", sign);

            var result = HttpUtil.Post(request.RequestUrl, request.GatewayData.ToUrl());

            var gatewayData = new GatewayData();
            gatewayData.FromJson(result);

            var baseResponse = (BaseResponse)(object)gatewayData.ToObject<TResponse>(StringCase.Lower);
            baseResponse.Raw = result;
            baseResponse.GatewayData = gatewayData;
            if (baseResponse.ReturnCode == "SUCCESS")
            {
                sign = gatewayData.GetStringValue("sign");

                if (!string.IsNullOrEmpty(sign) && !CheckSign(gatewayData, merchant.Key, sign))
                {
                    throw new GatewayException("签名验证失败");
                }

                baseResponse.Execute(merchant, request);
            }

            return (TResponse)(object)baseResponse;
        }

        private static void AddMerchant<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request, string gatewayUrl) where TResponse : IResponse
        {
            if (!string.IsNullOrEmpty(gatewayUrl))
            {
                _gatewayUrl = gatewayUrl;
            }

            if (!request.RequestUrl.StartsWith("http"))
            {
                request.RequestUrl = _gatewayUrl + request.RequestUrl;
            }
            request.GatewayData.Add(merchant, StringCase.Lower);
            ((BaseRequest<TModel, TResponse>)request).Execute(merchant);
        }

        internal static string BuildSign(GatewayData gatewayData, string key)
        {
            gatewayData.Remove("sign");
            gatewayData.Add("key", key);

            var data = gatewayData.ToUrl(false);
            var sign = EncryptUtil.MD5(data);

            gatewayData.Remove("key");

            return sign;
        }

        internal static bool CheckSign(GatewayData gatewayData, string key, string sign)
        {
            return BuildSign(gatewayData, key) == sign;
        }
    }
}
