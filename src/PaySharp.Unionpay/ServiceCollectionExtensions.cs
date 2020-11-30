#if NETCOREAPP
using System;
using Microsoft.Extensions.Configuration;
using PaySharp.Core;
using PaySharp.Unionpay;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IGateways UseUnionpay(this IGateways gateways, Action<Merchant> action)
        {
            if (action != null)
            {
                var merchant = new Merchant();
                action(merchant);
                gateways.Add(new UnionpayGateway(merchant));
            }

            return gateways;
        }

        public static IGateways UseUnionpay(this IGateways gateways, IConfiguration configuration)
        {
            var merchants = configuration.GetSection("PaySharp:Unionpays").Get<Merchant[]>();
            if (merchants != null)
            {
                for (var i = 0; i < merchants.Length; i++)
                {
                    var unionpayGateway = new UnionpayGateway(merchants[i]);
                    var gatewayUrl = configuration.GetSection($"PaySharp:Unionpays:{i}:GatewayUrl").Value;
                    if (!string.IsNullOrEmpty(gatewayUrl))
                    {
                        unionpayGateway.GatewayUrl = gatewayUrl;
                    }

                    gateways.Add(unionpayGateway);
                }
            }

            return gateways;
        }
    }
}

#endif
