#if NETCOREAPP3_1
using System;
using Microsoft.Extensions.Configuration;
using PaySharp.Core;
using PaySharp.Allinpay;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IGateways UseAllinpay(this IGateways gateways, Action<Merchant> action)
        {
            if (action != null)
            {
                var merchant = new Merchant();
                action(merchant);
                gateways.Add(new AllinpayGateway(merchant));
            }

            return gateways;
        }

        public static IGateways UseAllinpay(this IGateways gateways, IConfiguration configuration)
        {
            var merchants = configuration.GetSection("PaySharp:Allinpays").Get<Merchant[]>();
            if (merchants != null)
            {
                for (var i = 0; i < merchants.Length; i++)
                {
                    var allinpayGateway = new AllinpayGateway(merchants[i]);
                    var gatewayUrl = configuration.GetSection($"PaySharp:Allinpays:{i}:GatewayUrl").Value;
                    if (!string.IsNullOrEmpty(gatewayUrl))
                    {
                        allinpayGateway.GatewayUrl = gatewayUrl;
                    }

                    gateways.Add(allinpayGateway);
                }
            }

            return gateways;
        }
    }
}

#endif
