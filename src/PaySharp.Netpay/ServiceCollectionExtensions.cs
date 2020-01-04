#if NETCOREAPP3_1
using System;
using Microsoft.Extensions.Configuration;
using PaySharp.Netpay;
using PaySharp.Core;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IGateways UseNetpay(this IGateways gateways, Action<Merchant> action)
        {
            if (action != null)
            {
                var merchant = new Merchant();
                action(merchant);
                gateways.Add(new NetpayGateway(merchant));
            }

            return gateways;
        }

        public static IGateways UseNetpay(this IGateways gateways, IConfiguration configuration)
        {
            var merchants = configuration.GetSection("PaySharp:Netpays").Get<Merchant[]>();
            if (merchants != null)
            {
                for (var i = 0; i < merchants.Length; i++)
                {
                    var netpayGateway = new NetpayGateway(merchants[i]);
                    var gatewayUrl = configuration.GetSection($"PaySharp:Netpays:{i}:GatewayUrl").Value;
                    if (!string.IsNullOrEmpty(gatewayUrl))
                    {
                        netpayGateway.GatewayUrl = gatewayUrl;
                    }

                    gateways.Add(netpayGateway);
                }
            }

            return gateways;
        }
    }
}

#endif
