#if NETSTANDARD2_0
using Microsoft.Extensions.Configuration;
using PaySharp.Core;
using PaySharp.Wechatpay;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IGateways UseWechatpay(this IGateways gateways, Action<Merchant> action)
        {
            if (action != null)
            {
                var merchant = new Merchant();
                action(merchant);
                gateways.Add(new WechatpayGateway(merchant));
            }

            return gateways;
        }

        public static IGateways UseWechatpay(this IGateways gateways, IConfigurationSection configuration)
        {
            var merchants = configuration.Get<Merchant[]>();
            if (merchants != null)
            {
                for (int i = 0; i < merchants.Length; i++)
                {
                    gateways.Add(new WechatpayGateway(merchants[i]));
                }
            }

            return gateways;
        }
    }
}

#endif