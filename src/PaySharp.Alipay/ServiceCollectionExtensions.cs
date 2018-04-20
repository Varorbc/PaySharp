#if NETSTANDARD2_0
using Microsoft.Extensions.Configuration;
using PaySharp.Alipay;
using PaySharp.Core;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IGateways UseAlipay(this IGateways gateways, Action<Merchant> action)
        {
            if (action != null)
            {
                var merchant = new Merchant();
                action(merchant);
                gateways.Add(new AlipayGateway(merchant));
            }

            return gateways;
        }

        public static IGateways UseAlipay(this IGateways gateways, IConfigurationSection configuration)
        {
            var merchants = configuration.Get<Merchant[]>();
            if (merchants != null)
            {
                for (int i = 0; i < merchants.Length; i++)
                {
                    gateways.Add(new AlipayGateway(merchants[i]));
                }
            }

            return gateways;
        }
    }
}

#endif