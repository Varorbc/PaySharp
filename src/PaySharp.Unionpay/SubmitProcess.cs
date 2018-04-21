using Org.BouncyCastle.Crypto;
using PaySharp.Core;
using PaySharp.Core.Exceptions;
using PaySharp.Core.Request;
using PaySharp.Core.Response;
using PaySharp.Core.Utils;
using PaySharp.Unionpay.Response;
using System;
using System.Threading.Tasks;

namespace PaySharp.Unionpay
{
    internal static class SubmitProcess
    {
        private static string _gatewayUrl;

        internal static TResponse Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request, string gatewayUrl = null) where TResponse : IResponse
        {
            AddMerchant(merchant, request, gatewayUrl);

            string result = null;
            Task.Run(async () =>
            {
                result = await HttpUtil
                 .PostAsync(request.RequestUrl, request.GatewayData.ToUrl());
            })
            .GetAwaiter()
            .GetResult();

            var gatewayData = new GatewayData();
            gatewayData.FromUrl(result, false);

            var baseResponse = (BaseResponse)(object)gatewayData.ToObject<TResponse>(StringCase.Camel);
            baseResponse.Raw = result;
            if (baseResponse.RespCode == "00")
            {
                string sign = gatewayData.GetStringValue("signature");

                if (!string.IsNullOrEmpty(sign) && !CheckSign(gatewayData, sign, baseResponse.SignPubKeyCert))
                {
                    throw new GatewayException("签名验证失败");
                }

                baseResponse.Sign = sign;
                baseResponse.Execute(merchant, request);
            }

            return (TResponse)(object)baseResponse;
        }

        internal static TResponse SdkExecute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request, string gatewayUrl) where TResponse : IResponse
        {
            AddMerchant(merchant, request, gatewayUrl);

            return (TResponse)Activator.CreateInstance(typeof(TResponse), request);
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
            request.GatewayData.Add(merchant, StringCase.Camel);
            if (!string.IsNullOrEmpty(request.NotifyUrl))
            {
                request.GatewayData.Add("backUrl", request.NotifyUrl);
            }
            if (!string.IsNullOrEmpty(request.ReturnUrl))
            {
                request.GatewayData.Add("frontUrl", request.ReturnUrl);
            }
            request.GatewayData.Add("signature", BuildSign(request.GatewayData, merchant.CertKey));
        }

        internal static string BuildSign(GatewayData gatewayData, AsymmetricKeyParameter asymmetricKeyParameter)
        {
            gatewayData.Remove("signature");

            return Util.Sign(asymmetricKeyParameter, gatewayData.ToUrl(false));
        }

        internal static bool CheckSign(GatewayData gatewayData, string sign, string signPubKeyCert)
        {
            gatewayData.Remove("signature");

            return Util.VerifyData(gatewayData.ToUrl(false), sign, signPubKeyCert);
        }
    }
}
